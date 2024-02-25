using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : BaseState
{
    private EnemyLifeSM _sm;

    public EnemyDeath(EnemyLifeSM stateMachine) : base("EnemyDeath", stateMachine)
    {
        _sm = (EnemyLifeSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Die();
        _sm.dead = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();
       
    }
    private void Die()
    {
        _sm.removeOBG();
        Debug.Log("Die");
    }
}
