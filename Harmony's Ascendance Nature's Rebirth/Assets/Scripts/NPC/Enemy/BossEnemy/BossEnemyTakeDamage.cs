using System;
using CustomObjects;
using Player;
using UnityEngine;

namespace Enemy.BossEnemy
{
    public class BossEnemyTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;
        public ProjectileStats projectile;
        

        private void OnTriggerEnter(Collider other)
        {
            float damage = projectile.attackDamage;
            float currentHealth = enemyHealth.getValue();
            enemyHealth.setValue(currentHealth - damage);
            
        }
    }
}