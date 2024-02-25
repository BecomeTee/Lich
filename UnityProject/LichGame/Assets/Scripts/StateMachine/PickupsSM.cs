using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSM : StateMachine
{


    [HideInInspector]
    public PickupsIdle idleState;
    [HideInInspector]
    public PickupsGot gotState;

    public bool On;

    private void Awake()
    {
        idleState = new PickupsIdle(this);
        gotState = new PickupsGot(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Key has taken (step 1)");
            On = false;
        }
    }

    public void removeOBG()
    {
        Destroy(gameObject);
    }
}
