using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [SerializeField] SwitchesClass _switches; public SwitchesClass Swiches { get { return _switches; } set { _switches = value; } }
    [System.Serializable]
    public class SwitchesClass
    {
        public bool Grounded;
        public bool Jump;
        public bool Fall;
    }



    private void Awake()
    {
        _stateFactory = new PlayerStateFactory(this);
        _currectState = _stateFactory.Grounded();
        _currectState.StateEnter();
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



    private void SwitchToJump()
    {
        if(_playerMovementController.IsGrounded()) _switches.Jump = true;
    }


    private void OnEnable()
    {
        PlayerInputController.Jump += SwitchToJump;
    }
    private void OnDisable()
    {
        PlayerInputController.Jump -= SwitchToJump;
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
}
