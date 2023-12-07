using System;
using System.Collections;
using CustomObjects;
using Enemy;
using Enemy.BossEnemy;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace NPC.Enemy.Critters
{
    public class CritterTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        // [SerializeField] private GameObject deathEffect;

        private void Start()
        {
            // deathEffect.SetActive(false);
            enemyHealth.ValueChanged.AddListener(enemyDead);
        }

        private void OnDestroy()
        {
            enemyHealth.ValueChanged.RemoveListener(enemyDead);
        }

        private void enemyDead(float health)
        {
            if (health <= 0)
            {
                animator.SetBool("isDead", true);
                agent.isStopped = true;
                DeathEffect(); // Not working atm
                Destroy(gameObject);
            }
        }

        private void DeathEffect()
        {
            // deathEffect.SetActive(true); // I thought an effect could play on awake before the enemy is destroyed, but it'll probably need a timer
        }
    }

}