using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : BaseState
{
    private PlayerMovementSM _sm;

    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;


    public PlayerJump(PlayerMovementSM stateMachine) : base("PlayerJump", stateMachine)
    {
        _sm = (PlayerMovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _verticalInput = 0f;
        _jumpInput = 0f;

        _sm.JumpSound.Play();
    }

    public override void UpdateLogic()
    {
        //Debug.Log("Джумп");

        base.UpdateLogic();
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _jumpInput = Input.GetAxisRaw("Jump");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon && Mathf.Abs(_verticalInput) < Mathf.Epsilon && Mathf.Abs(_jumpInput) < Mathf.Epsilon && _sm.IsGrounded() && _sm.rb.velocity.y == 0)
        {
          //  Debug.Log("Смена на стоять");
            stateMachine.ChangeState(_sm.idleState);
        }
        else if(Mathf.Abs(_horizontalInput) > Mathf.Epsilon && Mathf.Abs(_jumpInput) < Mathf.Epsilon && _sm.IsGrounded() && _sm.rb.velocity.y == 0)
        {
            //Debug.Log("Смена на мув");
            stateMachine.ChangeState(_sm.moveState);
        }
        else if(_sm.rb.velocity.y < 2f && !_sm.IsGrounded())
        {
            //Debug.Log("Смена на падение");
            stateMachine.ChangeState(_sm.fallState);
        }

    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();

        //_sm.anim.SetFloat("Speed", Mathf.Abs(_horizontalInput));
        _sm.anim.SetBool("isJump", true);
        _sm.anim.SetBool("isGround", false);

        // Горизонтально
        Vector2 vel = _sm.rb.velocity;
        vel = new Vector2(_horizontalInput * _sm.speed, vel.y);
        _sm.rb.velocity = vel;

        if (Input.GetButtonDown("Jump") && _sm.IsGrounded())
        {
            Debug.Log("Прыг!");
            _sm.rb.velocity = new Vector2(_sm.rb.velocity.x, _sm.jumplenght);
        }


        if (!_sm.PLSM.dead)
        {
            //Разворот персонажа
            if (_horizontalInput > 0f)
            {
                _sm.transform.localScale = new Vector2(1, 1);
            }
            else if (_horizontalInput < 0f)
            {
                _sm.transform.localScale = new Vector2(-1, 1);
            }
        }

        

    }
}
