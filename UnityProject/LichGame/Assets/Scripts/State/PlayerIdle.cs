using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : BaseState
{
    private PlayerMovementSM _sm;

    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;


    public PlayerIdle(PlayerMovementSM stateMachine) : base("PlayerIdle", stateMachine)
    {
        _sm = (PlayerMovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _verticalInput = 0f;
        _jumpInput = 0f;

        
    }

    public override void UpdateLogic()
    {
        //Debug.Log("Стоит");
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _jumpInput = Input.GetAxisRaw("Jump");
        if ((Mathf.Abs(_horizontalInput) > Mathf.Epsilon || Mathf.Abs(_verticalInput) > Mathf.Epsilon) && Mathf.Abs(_jumpInput) < Mathf.Epsilon && _sm.IsGrounded())
        {
            //  Debug.Log("Смена на мув");
            
            stateMachine.ChangeState(_sm.moveState);
        }
        else if (Mathf.Abs(_jumpInput) > Mathf.Epsilon && _sm.IsGrounded())
        {
            //Debug.Log("Смена на прыжок");
            stateMachine.ChangeState(_sm.jumpState);
        }
        else if (_sm.rb.velocity.y < 2f && !_sm.IsGrounded())
        {
            //Debug.Log("Смена на падение");
            stateMachine.ChangeState(_sm.fallState);
        }
    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();

        _sm.anim.SetFloat("Speed", Mathf.Abs(_horizontalInput));
        _sm.anim.SetBool("isJump", false);
        _sm.anim.SetBool("isFall", false);
        _sm.anim.SetBool("isGround", true);

        if (Input.GetKeyDown("s"))
        {
            Debug.Log("Вниз!!!!!!!!!!!");
            _sm.IgnoreOn();

        }

    }
}
