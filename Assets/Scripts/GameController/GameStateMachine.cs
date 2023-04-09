using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    private GameBaseState _currectState; public GameBaseState CurrentState { get { return _currectState; } set { _currectState = value; } }
    private GameStateFactory _stateFactory; public GameStateFactory StateFactory { get { return _stateFactory; } set { _stateFactory = value; } }
    [SerializeField] string _currentStateName; public string CurrentStateName { get { return _currentStateName; } set { _currentStateName = value; } }


    [Space(20)]
    [Header("====References====")]
    [SerializeField] CanvasController _canvasController; public CanvasController CanvasController { get { return _canvasController; } }

    [SerializeField] SwitchesClass _switches; public SwitchesClass Swiches { get { return _switches; } set { _switches = value; } }
    [System.Serializable]
    public class SwitchesClass
    {
        public bool Menu;
        public bool Gameplay;
        public bool Pause;
        public bool Exit;
        public bool PlayerDied;
    }





    private void Awake()
    {
        _stateFactory = new GameStateFactory(this);
        _currectState = _stateFactory.Gameplay();
        _currectState.StateEnter();
        _switches.Gameplay = true;
    }
    private void Update()
    {
        _currectState.StateCheckChange();
    }



    public void SwitchToMenu()
    {
        _switches.Gameplay = false;
        _switches.Menu = true;
        _switches.Pause = false;
        StartCoroutine(GoToMainMenu());
    }
    public void SwitchToGameplay()
    {
        _switches.Gameplay = true;
    }
    public void SwitchToPause()
    {
        _switches.Gameplay = true;
        _switches.Pause = !_switches.Pause;
    }
    private void SwitchToPlayerDied()
    {
        _switches.PlayerDied = true;

        //_currectState.
    }


    private void OnEnable()
    {
        GameInputController.Pause += SwitchToPause;
        PlayerStats.Death += SwitchToPlayerDied;
    }
    private void OnDisable()
    {
        GameInputController.Pause -= SwitchToPause;
        PlayerStats.Death -= SwitchToPlayerDied;
    }


    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(3.35f);
        SceneManager.LoadScene("MenuEnterCutScene");
    }
}







public class GameStateFactory
{
    private GameStateMachine _ctx;

    public delegate void GameStateFactoryEvent();
    public static event GameStateFactoryEvent MenuEvent;
    public static event GameStateFactoryEvent GameplayEvent;
    public static event GameStateFactoryEvent PauseEvent;

    public GameStateFactory(GameStateMachine ctx)
    {
        _ctx = ctx;
    }


    public GameBaseState Menu()
    {
        MenuEvent();
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new GameMenuState(_ctx, this, stateName);
    }
    public GameBaseState Gameplay()
    {
        //GameplayEvent();
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new GameGameplayState(_ctx, this, stateName);
    }
    public GameBaseState Pause()
    {
        //PauseEvent();
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new GamePauseState(_ctx, this, stateName);
    }
    public GameBaseState PlayerDied()
    {
        string stateName = MethodBase.GetCurrentMethod().Name;
        return new GamePlayerDiedState(_ctx, this, stateName);
    }
}
