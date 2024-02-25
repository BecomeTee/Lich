using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlive : BaseState
{
    private EnemyLifeSM _sm;

    //private int Health;

    public EnemyAlive(EnemyLifeSM stateMachine) : base("EnemyAlive", stateMachine)
    {
        _sm = (EnemyLifeSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.Health = 30;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.Health <= 0)
        {
            stateMachine.ChangeState(_sm.deathState);
        }
    }

}
