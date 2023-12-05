using System;
using CustomObjects;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.BossEnemy
{
    public class BossEnemyTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;
        [SerializeField]private Animator animator;
        [SerializeField] private NavMeshAgent agent;

        private void OnTriggerEnter(Collider other)
        {
            ProjectileStats ps = other.gameObject.GetComponent<ProjectileStats>();
            float damage = ps.attackDamage;
            float currentHealth = enemyHealth.getValue();
            enemyHealth.setValue(Mathf.Max(currentHealth - damage,0));
            other.gameObject.SetActive(false);
            if (enemyHealth.getValue() <= 0)
            {
                animator.SetBool("isDead",true);
                agent.isStopped = true;
            }
        }
    }
}