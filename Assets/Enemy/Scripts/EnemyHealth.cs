using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator enemyAnimator;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            DestroyEnemy();
        }
        
    }

    private void DestroyEnemy()
    {
        if (isDead) return;
        isDead = true;
        enemyAnimator.SetTrigger("die");
        //Destroy(gameObject);
    }
}
