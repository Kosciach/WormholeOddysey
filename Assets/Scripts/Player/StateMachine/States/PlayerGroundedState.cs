using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) : base(ctx, factory, stateName)
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
        _ctx.MovementController.GroundedMovement();
    }
    public override void StateCheckChange()
    {
        if (_ctx.Swiches.Jump) StateChange(_factory.Jump());
    }
    public override void StateExit()
    {
        _ctx.Swiches.Grounded = false;
    }
}
