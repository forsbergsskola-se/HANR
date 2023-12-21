using System;
using System.Collections;
using CustomObjects;
using Enemy;
using Enemy.BossEnemy;
using Player;
using UI;
using UnityEngine;
using UnityEngine.AI;

namespace NPC.Enemy.Critters
{
    public class CritterTakeDamageG : MonoBehaviour
    {
        public FloatVariable CritterHealthG;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private GameObject deathEffect;
        private PlayerStat playerstat;
        [SerializeField] private Experience exp;
        public BoolVariable playerInRangeOfCritterG;
        public BoolVariable playerInAttackRangeOfCritterG;
        public Quest quest;
        
        private void Start()
        {
            playerstat = GameObject.FindWithTag("Player").GetComponent<PlayerStat>();
            CritterHealthG.ValueChanged.AddListener(enemyDead);
        }

        private void OnDestroy()
        {
            quest.killCountCritter++;
            float newexp = playerstat.exp.getValue() + exp.exp;
            playerstat.exp.setValue(newexp);
            CritterHealthG.ValueChanged.RemoveListener(enemyDead);
        }

        private void enemyDead(float health)
        {
            if (health <= 0)
            {
                animator.SetBool("IsDead",true);
                playerInRangeOfCritterG.setValue(false);
                playerInAttackRangeOfCritterG.setValue(false);
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