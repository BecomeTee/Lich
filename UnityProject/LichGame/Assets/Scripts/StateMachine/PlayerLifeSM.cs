using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeSM : StateMachine
{
    [HideInInspector]
    public PlayerAlive aliveState;
    [HideInInspector]
    public PlayerDeath deathState;

    [SerializeField] public AudioSource DeadSound;
    [SerializeField] public AudioSource HitSound;

    public int Health;
    [SerializeField] Sprite[] spritesHP;
    [SerializeField] private GameObject HealthBar;
    public bool haveDamage = false;
    public bool dead = false;
    //private SpriteRenderer healthBarRenderer;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer rbSprite;
    public Transform PlayerTransform;

    private void Awake()
    {
        aliveState = new PlayerAlive(this);
        deathState = new PlayerDeath(this);
    }

    protected override BaseState GetInitialState()
    {
        return aliveState;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("Death");
            HitSound.Play();
            Health = 0;
            ChangeHealsBar();
        }
        if (collision.gameObject.CompareTag("Hurt") && !collision.gameObject.GetComponent<EnemyLifeSM>().dead)
        {
            Debug.Log("Hurt");
            HitSound.Play();
            Health--;
            ChangeHealsBar();
            haveDamage = true;
            StartCoroutine(ContDamage());

        }
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Spike");
            HitSound.Play();
            Health -= 2;
            ChangeHealsBar();
            haveDamage = true;
            StartCoroutine(ContDamage());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hurt"))
        {
            haveDamage = false;
        }
        if (collision.gameObject.CompareTag("Spikes"))
        {
            haveDamage = false;
        }
    }

    public void ChangeHealsBar()
    {
        if(Health == 3)
        {
            Debug.Log("hp = 3");
            HealthBar.GetComponent<SpriteRenderer>().sprite = spritesHP[3];
            return;
        }
        else if(Health == 2)
        {
            Debug.Log("hp = 2");
            HealthBar.GetComponent<SpriteRenderer>().sprite = spritesHP[2];
            return;
        }
        else if(Health == 1)
        {
            Debug.Log("hp = 1");
            HealthBar.GetComponent<SpriteRenderer>().sprite = spritesHP[1];
            return;
        }
        else if(Health <= 0)
        {
            Debug.Log("hp = 0");
            HealthBar.GetComponent<SpriteRenderer>().sprite = spritesHP[0];
            return;
        }

    }


    IEnumerator ContDamage()
    {
        yield return new WaitForSeconds(0.7f);
        while (haveDamage)
        {
            HitSound.Play();
            Debug.Log("Corutina");
            Health--;
            ChangeHealsBar();
            yield return new WaitForSeconds(0.7f);
        }
        
    }

    public void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
