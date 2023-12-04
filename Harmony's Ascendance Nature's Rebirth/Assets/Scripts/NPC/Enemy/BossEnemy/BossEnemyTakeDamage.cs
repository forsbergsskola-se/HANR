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
            enemyHealth.setValue(projectile.attackDamage);
        }
    }
}