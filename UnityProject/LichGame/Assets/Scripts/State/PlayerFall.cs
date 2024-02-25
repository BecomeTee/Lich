using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : BaseState
{
    private PlayerMovementSM _sm;

    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;

    public PlayerFall(PlayerMovementSM stateMachine) : base("PlayerFall", stateMachine)
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
        //Debug.Log("Падение");

        base.UpdateLogic();
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _jumpInput = Input.GetAxisRaw("Jump");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon && Mathf.Abs(_verticalInput) < Mathf.Epsilon && Mathf.Abs(_jumpInput) < Mathf.Epsilon && _sm.IsGrounded() && _sm.rb.velocity.y == 0)
        {
            //Debug.Log("Смена на стоять");
            stateMachine.ChangeState(_sm.idleState);
        }
        else if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon && Mathf.Abs(_jumpInput) < Mathf.Epsilon && _sm.IsGrounded() && _sm.rb.velocity.y == 0)
        {
            //Debug.Log("Смена на мув");
            stateMachine.ChangeState(_sm.moveState);
        }
        else if (Mathf.Abs(_jumpInput) > Mathf.Epsilon && _sm.IsGrounded() && _sm.rb.velocity.y == 0)
        {
            //Debug.Log("Смена на прыжок");
            stateMachine.ChangeState(_sm.jumpState);
        }

    }

    public override void UpdatePhisics()
    {
        base.UpdatePhisics();

        _sm.anim.SetBool("isJump", false);
        _sm.anim.SetBool("isFall", true);
        _sm.anim.SetBool("isGround", false);

        if (!_sm.PLSM.dead)
        {
            // Горизонтально
            Vector2 vel = _sm.rb.velocity;
            vel = new Vector2(_horizontalInput * _sm.speed, vel.y);
            _sm.rb.velocity = vel;
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
