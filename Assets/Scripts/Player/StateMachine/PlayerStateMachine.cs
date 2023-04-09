using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerBaseState _currectState; public PlayerBaseState CurrentState { get { return _currectState; } set { _currectState = value; } }
    private PlayerStateFactory _stateFactory; public PlayerStateFactory StateFactory { get { return _stateFactory; } set { _stateFactory = value; } }
    [SerializeField] string _currentStateName; public string CurrentStateName { get { return _currentStateName; } set { _currentStateName = value; } }

    [Space(20)]
    [Header("====PlayerScripts====")]
    [SerializeField] PlayerMovementController _playerMovementController; public PlayerMovementController MovementController { get { return _playerMovementController; } }
    [SerializeField] PlayerAnimatorScript _playerAnimationScript; public PlayerAnimatorScript PlayerAnimatorScript { get { return _playerAnimationScript; } }


    [Space(20)]
    [Header("====References====")]
    [SerializeField] Rigidbody2D _rigidbody; public Rigidbody2D Rigidbody { get { return _rigidbody;} set { _rigidbody = value; } }
    [SerializeField] PlayableDirector _timeLine; public PlayableDirector TimeLine { get { return _timeLine; } }
    [SerializeField] VisualEffect _playerLandEffect; public VisualEffect PlayerLandEffect { get { return _playerLandEffect; } }

    [SerializeField] SwitchesClass _switches; public SwitchesClass Swiches { get { return _switches; } set { _switches = value; } }
    [System.Serializable]
    public class SwitchesClass
    {
        public bool Grounded;
        public bool Jump;
        public bool Fall;
        public bool Menu;
    }



    private void Awake()
    {
        _stateFactory = new PlayerStateFactory(this);
        _currectState = _stateFactory.Grounded();
        _currectState.StateEnter();
        _switches.Grounded = true;
    }
    private void Update()
    {
        _currectState.StateUpdate();
        _currectState.StateCheckChange();
    }
    private void FixedUpdate()
    {
        _currectState.StateFixedUpdate();
    }


    public void SpawnLandEffect()
    {
        Destroy(Instantiate(_playerLandEffect, transform.position, Quaternion.identity), 3);
    }

    private void SwitchToJump()
    {
        if(_playerMovementController.IsGrounded()) _switches.Jump = true;
    }
    private void SwitchToGrounded()
    {
        _switches.Grounded = true;
    }
    private void SwitchToMenu()
    {
        _switches.Grounded = false;
        _switches.Jump = false;
        _switches.Fall = false;
        _switches.Menu = true;

        _currectState.StateExit();
        _currectState = _stateFactory.Menu();
        _currectState.StateEnter();
    }


    private void OnEnable()
    {
        PlayerInputController.Jump += SwitchToJump;
        GameStateFactory.GameplayEvent += SwitchToGrounded;
        GameStateFactory.MenuEvent += SwitchToMenu;
    }
    private void OnDisable()
    {
        PlayerInputController.Jump -= SwitchToJump;
        GameStateFactory.GameplayEvent -= SwitchToGrounded;
        GameStateFactory.MenuEvent -= SwitchToMenu;
    }
}







public class PlayerStateFactory
{
    protected PlayerStateMachine _ctx;

    public PlayerStateFactory(PlayerStateMachine ctx)
    {
        _ctx = ctx;
    }



    public PlayerBaseState Grounded()
    {
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new PlayerGroundedState(_ctx, this, stateName);
    }
    public PlayerBaseState Jump()
    {
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new PlayerJumpState(_ctx, this, stateName);
    }
    public PlayerBaseState Fall()
    {
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new PlayerFallState(_ctx, this, stateName);
    }
    public PlayerBaseState Menu()
    {
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new PlayerMenuState(_ctx, this, stateName);
    }
}