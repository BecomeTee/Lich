using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    public Animator animator;

    public Transform fightPoint;
    public float fightRange = 0.5f;
    public LayerMask LayerEnemy;

    [SerializeField] GameObject PLSM;
    [SerializeField] public AudioSource FightAudio;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    bool fight = false;

    void Update()
    {

        animator.SetBool("Fight", fight);
        if (Time.time >= nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.L) && PLSM.GetComponent<PlayerLifeSM>().dead == false)
            {
                FightAudio.Play();
                StartCoroutine(StartFight());
                Attack();
                Debug.Log("Fight");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    public void Attack()
    {
        

        Collider2D[] Enemy = Physics2D.OverlapCircleAll(fightPoint.position, fightRange, LayerEnemy);

        foreach(Collider2D enemy in Enemy)
        {
            Debug.Log("Удар!");
            enemy.GetComponent<EnemyLifeSM>().TakeDamage(20);

            var pushDir = (enemy.transform.position - transform.position).normalized;
            enemy.GetComponent<Rigidbody2D>().AddForce(pushDir * 800f, ForceMode2D.Impulse);
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        if (fightPoint == null)
            return;

        Gizmos.DrawWireSphere(fightPoint.position, fightRange);
    }

    IEnumerator StartFight()
    {
        fight = true;
        yield return new WaitForSeconds(0.01f);
        fight = false;
    }

    
}
