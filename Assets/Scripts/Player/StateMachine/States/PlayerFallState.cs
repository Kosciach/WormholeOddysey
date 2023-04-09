using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) : base(ctx, factory, stateName)
    {

    }

    public override void StateEnter()
    {
        //_ctx.PlayerAnimatorScript.FallAnimation();
        LeanTween.value(0, 0.5f, 0.3f).setOnUpdate((float val) =>
        {
            _ctx.Rigidbody.velocity -= new Vector2(0f, val);
        });
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
        if(_ctx.MovementController.IsGrounded())
        {
            _ctx.Swiches.Grounded = true;
            StateChange(_factory.Grounded());
        }
    }
    public override void StateExit()
    {
        _ctx.PlayerAnimatorScript.LandAnimation();
        _ctx.SpawnLandEffect();
        _ctx.Swiches.Fall = false;
    }
}
