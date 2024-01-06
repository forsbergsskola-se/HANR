using System;
using System.Collections;
using CustomObjects;
using Player;
using Player.SkillStats;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Enemy.BossEnemy
{
    public class BossEnemyTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;
        public BoolVariable playBossMusic;
        public BoolVariable isBossKilled;
        public UnityEvent bossKilled;
        
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject deathEffect;
        [SerializeField] private Experience exp;
        private PlayerStat playerStat;
        

        public Quest quest;
        private void Start()
        {
            playerStat = GameObject.FindWithTag("Player").GetComponent<PlayerStat>();
            enemyHealth.ValueChanged.AddListener(enemyDead);
            
        }

        private void OnDestroy()
        {
            quest.killCountBoss++;
            playBossMusic.setValue(false);
            float newexp = playerStat.exp.getValue() + exp.exp;
            playerStat.exp.setValue(newexp);
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
            
            
            bossKilled.Invoke();
            isBossKilled.setValue(true);
            
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