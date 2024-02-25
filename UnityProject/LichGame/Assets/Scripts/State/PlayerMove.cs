using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : BaseState
{
    private PlayerMovementSM _sm;

    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;

    
    public PlayerMove(PlayerMovementSM stateMachine) : base("PlayerMove", stateMachine)
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
        //Debug.Log("Мувает");
        
        base.UpdateLogic();
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _jumpInput = Input.GetAxisRaw("Jump");
        
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon && Mathf.Abs(_verticalInput) < Mathf.Epsilon && Mathf.Abs(_jumpInput) < Mathf.Epsilon && _sm.IsGrounded())
        {
            //Debug.Log("Смена на стоять");
            
            stateMachine.ChangeState(_sm.idleState);
        }
        else if (Mathf.Abs(_jumpInput) > Mathf.Epsilon && _sm.IsGrounded())
        {
            //Debug.Log("Смена на прыг");
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

        // Горизонтально
        Vector2 vel = _sm.rb.velocity;
        vel = new Vector2(_horizontalInput * _sm.speed, vel.y);
        _sm.rb.velocity = vel;

        

        if (Input.GetKeyDown("s"))
        {
            Debug.Log("Вниз!!!!!!!!!!!");
            _sm.IgnoreOn();
            
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
