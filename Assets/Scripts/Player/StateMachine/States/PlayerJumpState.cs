using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) : base(ctx, factory, stateName)
    {

    }

    public override void StateEnter()
    {
        AudioController.Instance.PlaySound(2);
        _ctx.PlayerAnimatorScript.JumpAnimation();
        _ctx.MovementController.Jump();
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
        if (_ctx.Rigidbody.velocity.y < 0)
        {
            _ctx.Swiches.Fall = true;
            StateChange(_factory.Fall());
        }
    }
    public override void StateExit()
    {
        _ctx.Swiches.Jump = false;
    }
}
