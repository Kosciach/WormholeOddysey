using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBaseState
{
    protected GameStateMachine _ctx;
    protected GameStateFactory _factory;

    public GameBaseState(GameStateMachine ctx, GameStateFactory factory, string stateName)
    {
        _ctx = ctx;
        _factory = factory;
        _ctx.CurrentStateName = stateName;
    }


    public abstract void StateEnter();
    public abstract void StateCheckChange();
    public abstract void StateExit();


    protected void StateChange(GameBaseState newState)
    {
        StateExit();
        _ctx.CurrentState = newState;
        _ctx.CurrentState.StateEnter();
    }
}
