using System;
using CustomObjects;
using Player;
using UnityEngine;

namespace Enemy.BossEnemy
{
    public class BossEnemyTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;

        private void OnTriggerEnter(Collider other)
        {
            ProjectileStats ps = other.gameObject.GetComponent<ProjectileStats>();
            float damage = ps.attackDamage;
            float currentHealth = enemyHealth.getValue();
            enemyHealth.setValue(currentHealth - damage);
            other.gameObject.SetActive(false);
        }
    }
}