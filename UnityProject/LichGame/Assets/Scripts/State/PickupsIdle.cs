using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsIdle : BaseState
{

    private PickupsSM _sm;

    public PickupsIdle(PickupsSM stateMachine) : base("PickupsIdle", stateMachine)
    {
        _sm = (PickupsSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.On = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!_sm.On)
        {
            stateMachine.ChangeState(_sm.gotState);
        }
    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();

    }
}
