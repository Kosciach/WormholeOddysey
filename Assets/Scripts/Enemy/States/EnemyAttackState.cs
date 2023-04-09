using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName) : base(ctx, factory, stateName)
    {

    }

    public override void StateEnter()
    {

    }
    public override void StateUpdate()
    {
        _ctx.ProjectileSpawner.SpawningTimer();
    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {
        if (!_ctx.PlayerDetector.IsPlayerDetected)
        {
            StateChange(_factory.Idle());
            _ctx.Swiches.Idle = true;
        }
    }
    public override void StateExit()
    {
        _ctx.Swiches.Attack = false;
    }
}
