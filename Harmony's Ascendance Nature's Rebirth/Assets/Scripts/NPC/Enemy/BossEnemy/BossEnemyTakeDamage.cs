using System;
using System.Collections;
using CustomObjects;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.BossEnemy
{
    public class BossEnemyTakeDamage : MonoBehaviour
    {
        public FloatVariable enemyHealth;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        private HitEffectPool hitEffectPool;
        public GameObjectVariable currentClickedEnemy;
        private void Start()
        {
            hitEffectPool = this.gameObject.GetComponent<HitEffectPool>();
        }

        private void OnTriggerEnter(Collider other)
        {
            ProjectileStats ps = other.gameObject.GetComponent<ProjectileStats>();
            float damage = ps.attackDamage;
            float currentHealth = enemyHealth.getValue();
            enemyHealth.setValue(Mathf.Max(currentHealth - damage,0));
            other.gameObject.SetActive(false);
            StartCoroutine(ShowEffect());
            if (enemyHealth.getValue() <= 0)
            {
                animator.SetBool("isDead",true);
                agent.isStopped = true;
                
                DeathEffect();
                Destroy(gameObject);
            }
        }

        private IEnumerator ShowEffect()
        {
            GameObject hitEffect = hitEffectPool.GetPooledEffects();
            if (hitEffect != null)
            {
                hitEffect.transform.position = this.gameObject.GetComponentInChildren<HitPoint>().transform.position;;
                hitEffect.transform.rotation = this.gameObject.GetComponentInChildren<HitPoint>().transform.rotation;
                hitEffect.transform.localScale = new Vector3(3f, 3f, 3f);
            }

            yield return new WaitForSeconds(2);
            hitEffect.SetActive(false);
        }
        
        private void DeathEffect()
        {
            Debug.Log("Bang");
        }
    }
}