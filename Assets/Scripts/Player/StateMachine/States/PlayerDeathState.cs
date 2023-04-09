using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathState : PlayerBaseState
{
    private float _resetSceneTime = 200;
    private bool _isReset;
    public PlayerDeathState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) : base(ctx, factory, stateName)
    {

    }

    public override void StateEnter()
    {
        _ctx.PlayerStats.ToggleCanTakeDamage(false);
        _ctx.Rigidbody.isKinematic = true;
        _ctx.transform.localScale = Vector3.zero;
        _ctx.InstanciateDeathEffect();
    }
    public override void StateUpdate()
    {
        _ctx.Rigidbody.velocity = Vector2.zero;

        _resetSceneTime -= 100 * Time.deltaTime;
        _resetSceneTime = Mathf.Clamp(_resetSceneTime, 0, 100);

        if (_resetSceneTime == 0)
        {
            if (_isReset) return;
            _isReset = true;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {
        _ctx.Swiches.Death = false;
    }
}
