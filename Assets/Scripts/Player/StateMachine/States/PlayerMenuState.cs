using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuState : PlayerBaseState
{
    public PlayerMenuState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) : base(ctx, factory, stateName)
    {

    }

    public override void StateEnter()
    {
        _ctx.Rigidbody.isKinematic = true;
        _ctx.Rigidbody.velocity = Vector2.zero;
        _ctx.PlayerAnimatorScript.GroundedAnimation();
        _ctx.TimeLine.Play();
    }
    public override void StateUpdate()
    {

    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {
        _ctx.Swiches.Menu = false;
    }
}
