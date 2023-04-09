using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerDiedState : GameBaseState
{

    public GamePlayerDiedState(GameStateMachine ctx, GameStateFactory factory, string stateName) : base(ctx, factory, stateName){}



    public override void StateEnter()
    {

    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {
        _ctx.Swiches.PlayerDied = false;
    }
}
