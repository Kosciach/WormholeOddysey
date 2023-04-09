using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName) : base(ctx, factory, stateName)
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
        if(_ctx.PlayerDetector.IsPlayerDetected)
        {
            StateChange(_factory.Attack());
            _ctx.Swiches.Attack = true;
        }
    }
    public override void StateExit()
    {
        _ctx.Swiches.Idle = false;
    }
}
