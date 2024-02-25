using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : BaseState
{
    private PlayerLifeSM _sm;

    bool dead = false;

    public PlayerDeath(PlayerLifeSM stateMachine) : base("PlayerDeath", stateMachine)
    {
        _sm = (PlayerLifeSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.dead = true;
        _sm.DeadSound.Play();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();
        /*_sm.rb.bodyType = RigidbodyType2D.Static;
        RestartLvl();*/
        if (!dead )
        {
            dead = true;
            _sm.anim.SetTrigger("Death");
            Die();
        }
        
    }
    private void Die()
    {
        _sm.rb.bodyType = RigidbodyType2D.Static;
        //RestartLvl();
        
    }
    
}
