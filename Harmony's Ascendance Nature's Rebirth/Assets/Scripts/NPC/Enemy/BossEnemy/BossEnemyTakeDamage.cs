using System;
using System.Collections;
using CustomObjects;
using Player;
using Player.SkillStats;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy.BossEnemy
{
    public class BossEnemyTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject deathEffect;
        private void Start()
        {
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
                animator.SetBool("isDead",true);
            }
        }

        private void DeathEffect()
        {
            GameObject effect  = Instantiate(deathEffect, this.transform);
            effect.transform.position = this.transform.position;
            
            StartCoroutine(removeObjects(effect));
        }

        private IEnumerator removeObjects(GameObject effect)
        {
            yield return new WaitForSeconds(2);
            Destroy(effect);
            Destroy(this.gameObject);
        }
    }
}