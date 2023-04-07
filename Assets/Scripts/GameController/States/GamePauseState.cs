using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameBaseState
{

    public GamePauseState(GameStateMachine ctx, GameStateFactory factory, string stateName) : base(ctx, factory, stateName){}



    public override void StateEnter()
    {
        _ctx.CanvasController.SwitchScreen(_ctx.CurrentStateName);
    }
    public override void StateCheckChange()
    {
        if (!_ctx.Swiches.Pause)
        {
            if (_ctx.Swiches.Menu) StateChange(_factory.Menu());
            else if (_ctx.Swiches.Gameplay) StateChange(_factory.Gameplay());
        }
    }
    protected override void StateExit()
    {
        _ctx.Swiches.Pause = false;
    }
}
