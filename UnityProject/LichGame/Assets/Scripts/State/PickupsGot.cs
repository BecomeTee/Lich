using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsGot : BaseState
{

    private PickupsSM _sm;

    public PickupsGot(PickupsSM StateMachine) : base("PickupsGot", StateMachine)
    {
        _sm = (PickupsSM)StateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();
        //animation
        //Debug.Log("Key has taken (step 2)");
        _sm.removeOBG();
    }

}
