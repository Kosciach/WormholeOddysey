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
    [SerializeField] EnemyMovementController _movementController; public EnemyMovementController MovementController { get { return _movementController; } }
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
}
