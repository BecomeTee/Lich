using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachine
{
    [HideInInspector]
    public PlayerIdle idleState;
    [HideInInspector]
    public PlayerMove moveState;
    [HideInInspector]
    public PlayerJump jumpState;
    [HideInInspector]
    public PlayerFall fallState;

    [SerializeField] public AudioSource JumpSound;

    public Rigidbody2D rb;
    public Collider2D col;
    public Animator anim;
    public SpriteRenderer rbSprite;

    public int PlayerLayer;
    public int PlatformLayer;
    public int StickyPlatformLayer;

    public Vector2 direcrion;
    public float speed = 10f;
    public float fallSpeed = 2f;
    public float jumplenght = 12f;
    public float distance = 2f;
    //public bool jump;

    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private LayerMask Wall;

    [SerializeField] public PlayerLifeSM PLSM;

    private void Awake()
    {
        idleState = new PlayerIdle(this);
        moveState = new PlayerMove(this);
        jumpState = new PlayerJump(this);
        fallState = new PlayerFall(this);

        PlatformLayer = LayerMask.NameToLayer("Platform");
        StickyPlatformLayer = LayerMask.NameToLayer("StickyPlatform");
        PlayerLayer = LayerMask.NameToLayer("Player");
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public bool IsGrounded()
    {
        return (Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, JumpableGround));   
    }
    
    public bool IsWall()
    {
        return (Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.right, .1f, Wall) || Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.left, .1f, Wall));   
    }

    public void IgnoreOn()
    {
        Physics2D.IgnoreLayerCollision(PlayerLayer, PlatformLayer, true);
        Physics2D.IgnoreLayerCollision(PlayerLayer, StickyPlatformLayer, true);
        Invoke("IgnoreOff", 0.3f);
    }

    public void IgnoreOff()
    {
        Physics2D.IgnoreLayerCollision(PlayerLayer, PlatformLayer, false);
        Physics2D.IgnoreLayerCollision(PlayerLayer, StickyPlatformLayer, false);
    }


}
