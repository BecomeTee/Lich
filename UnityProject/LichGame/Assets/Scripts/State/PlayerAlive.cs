using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlive : BaseState
{
    private PlayerLifeSM _sm;

    //private int Health;

    public PlayerAlive(PlayerLifeSM stateMachine) : base("PlayerAlive", stateMachine)
    {
        _sm = (PlayerLifeSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.Health = 3;
        _sm.ChangeHealsBar();
        _sm.dead = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(_sm.Health <= 0)
        {
            stateMachine.ChangeState(_sm.deathState);
        }
    }



}
