using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSM : StateMachine
{
    [HideInInspector]
    public EnemyAlive aliveState;
    [HideInInspector]
    public EnemyDeath deathState;

    public int Health;
    public bool dead = false;

    public Rigidbody2D rb;
    public SpriteRenderer rbSprite;

    private void Awake()
    {
        aliveState = new EnemyAlive(this);
        deathState = new EnemyDeath(this);
    }

    protected override BaseState GetInitialState()
    {
        return aliveState;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void removeOBG()
    {
        Destroy(gameObject, 0.5f);
        /*GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;*/
    }
}
