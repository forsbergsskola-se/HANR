using System.Collections;
using CustomObjects;
using Enemy;
using Enemy.BossEnemy;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace NPC.Enemy.Critters
{
    public class CritterTakeDamage : MonoBehaviour
    {
        public FloatVariable critterHealth;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        private HitEffectPool hitEffectPool;

        private void Start()
        {
            hitEffectPool = this.gameObject.GetComponent<HitEffectPool>();
        }

        private void OnTriggerEnter(Collider other)
        {
            ProjectileStats ps = other.gameObject.GetComponent<ProjectileStats>();
            float damage = ps.attackDamage;
            float currentHealth = critterHealth.getValue();
            critterHealth.setValue(Mathf.Max(currentHealth - damage,0));
            other.gameObject.SetActive(false);
            //StartCoroutine(showEffect());
            if (critterHealth.getValue() <= 0)
            {
                animator.SetBool("isDead",true);
                agent.isStopped = true;
            }
        }

        private IEnumerator showEffect()
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
    }
}