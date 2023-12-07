using System;
using CustomObjects;
using Enemy;
using Enemy.BossEnemy;
using UnityEngine;

namespace Colliders
{
    public class FireBallCollider : MonoBehaviour
    {
        public Skills skills;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
            } 
            else if(other.CompareTag("Enemy"))
            {
                FloatVariable health = other.GetComponent<EnemyStats>().enemyHealth;
                health.setValue(Mathf.Max(health.getValue() - skills.damage,0));
                Destroy(this.gameObject);
            }
        }
    }
}