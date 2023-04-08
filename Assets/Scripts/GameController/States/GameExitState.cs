using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExitState : GameBaseState
{
    public GameExitState(GameStateMachine ctx, GameStateFactory factory, string stateName) : base(ctx, factory, stateName){}



    public override void StateEnter()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public override void StateCheckChange()
    {

    }
    protected override void StateExit()
    {
        _ctx.Swiches.Exit = false;
    }
}
