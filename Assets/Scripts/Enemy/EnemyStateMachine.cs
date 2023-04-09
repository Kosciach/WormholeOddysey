using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private EnemyBaseState _currectState; public EnemyBaseState CurrentState { get { return _currectState; } set { _currectState = value; } }
    private EnemyStateFactory _stateFactory; public EnemyStateFactory StateFactory { get { return _stateFactory; } set { _stateFactory = value; } }
    [SerializeField] string _currentStateName; public string CurrentStateName { get { return _currentStateName; } set { _currentStateName = value; } }


    [Space(20)]
    [Header("====EnemyScripts====")]
    [SerializeField] PlayerDetector _playerDetector; public PlayerDetector PlayerDetector { get { return _playerDetector; } }
    [SerializeField] EnemyProjectileSpawner _projectileSpawner; public EnemyProjectileSpawner ProjectileSpawner { get { return _projectileSpawner; } }


    [SerializeField] SwitchesClass _switches; public SwitchesClass Swiches { get { return _switches; } set { _switches = value; } }
    [System.Serializable]
    public class SwitchesClass
    {
        public bool Idle;
        public bool Attack;
    }



    private void Awake()
    {
        _stateFactory = new EnemyStateFactory(this);
        _currectState = _stateFactory.Idle();
        _currectState.StateEnter();
        SwitchToIdle();
    }
    private void Update()
    {
        _currectState.StateUpdate();
        _currectState.StateCheckChange();
    }
    private void FixedUpdate()
    {
        _currectState.StateFixedUpdate();
    }



    private void SwitchToAttack()
    {
        _switches.Attack = true;
    }
    private void SwitchToIdle()
    {
        _switches.Idle = true;
    }
}




public class EnemyStateFactory
{
    protected EnemyStateMachine _ctx;

    public EnemyStateFactory(EnemyStateMachine ctx)
    {
        _ctx = ctx;
    }




    public EnemyBaseState Idle()
    {
        return new EnemyIdleState(_ctx, this, MethodBase.GetCurrentMethod().Name);
    }
    public EnemyBaseState Attack()
    {
        return new EnemyAttackState(_ctx, this, MethodBase.GetCurrentMethod().Name);
    }
}
