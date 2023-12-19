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
        public BoolVariable playCombatMusic;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject deathEffect;
        private PlayerStat playerStat;
        [SerializeField] private Experience exp;
        private void Start()
        {
            playerStat = GameObject.FindWithTag("Player").GetComponent<PlayerStat>();
            enemyHealth.ValueChanged.AddListener(enemyDead);
          
        }

        private void OnDestroy()
        {
            float newexp = playerStat.exp.getValue() + exp.exp;
            playerStat.exp.setValue(newexp);
            enemyHealth.ValueChanged.RemoveListener(enemyDead);
        }

        private void enemyDead(float health)
        {
            if (health <= 0)
            {
                animator.SetBool("isDead",true);
                playCombatMusic.setValue(false);
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