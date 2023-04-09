using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGameplayState : GameBaseState
{
    public GameGameplayState(GameStateMachine ctx, GameStateFactory factory, string stateName) : base(ctx, factory, stateName) { }



    public override void StateEnter()
    {
        _ctx.CanvasController.SwitchScreen(_ctx.CurrentStateName);
    }
    public override void StateCheckChange()
    {
        if (_ctx.Swiches.Pause) StateChange(_factory.Pause());
    }
    public override void StateExit()
    {
        _ctx.Swiches.Gameplay = false;
    }
}
