using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuState : PlayerBaseState
{
    public PlayerMenuState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) : base(ctx, factory, stateName)
    {

    }

    public override void StateEnter()
    {

    }
    public override void StateUpdate()
    {

    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {
        if (_ctx.Swiches.Grounded) StateChange(_factory.Grounded());
    }
    protected override void StateExit()
    {
        _ctx.Swiches.Menu = false;
    }
}
