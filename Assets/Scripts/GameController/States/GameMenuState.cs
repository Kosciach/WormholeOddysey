using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameBaseState
{

    public GameMenuState(GameStateMachine ctx, GameStateFactory factory, string stateName) : base(ctx, factory, stateName){}



    public override void StateEnter()
    {
        _ctx.CanvasController.SwitchScreen(_ctx.CurrentStateName);
    }
    public override void StateCheckChange()
    {
        if (_ctx.Swiches.Gameplay) StateChange(_factory.Gameplay());
        else if (_ctx.Swiches.Pause) StateChange(_factory.Pause());
    }
    protected override void StateExit()
    {
        _ctx.Swiches.Menu = false;
    }
}
