using System;
using System.Collections;
using CustomObjects;
using Enemy;
using Enemy.BossEnemy;
using Player.SkillStats;
using UnityEngine;

namespace Colliders
{
    public class ProjectileCollider : MonoBehaviour
    {
        private CombatStat cs;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                ProjectileStats ps = this.GetComponent<ProjectileStats>();
                cs = ps.cs;
                HitEffectPool hitEffectPool = other.GetComponent<HitEffectPool>();
                FloatVariable enemyHealth = other.GetComponent<EnemyStats>().enemyHealth;
                enemyHealth.setValue(Mathf.Max(enemyHealth.getValue() - cs.damage,0));
                StartCoroutine(ShowEffect(hitEffectPool, other.gameObject));
                this.gameObject.SetActive(false);

            } 
            else if (other.CompareTag("Ground"))
            {
                this.gameObject.SetActive(false);
            }
        }
        
        private IEnumerator ShowEffect( HitEffectPool hep, GameObject other)
        {
            GameObject hitEffect = hep.GetPooledEffects();
            if (hitEffect)
            {
                ParticleSystem psParent = hitEffect.GetComponent<ParticleSystem>();
                ParticleSystem psChild = hitEffect.GetComponentInChildren<ParticleSystem>();

                var psParentMain = psParent.main;
                psParentMain.startColor = cs.hitEffectColor;
                var psChildMain = psChild.main;
                psChildMain.startColor = cs.hitEffectColor;
                
                hitEffect.transform.position = other.gameObject.GetComponentInChildren<HitPoint>().transform.position;;
                hitEffect.transform.rotation = other.gameObject.GetComponentInChildren<HitPoint>().transform.rotation;
                hitEffect.transform.localScale = new Vector3(3f, 3f, 3f);
            }

            yield return new WaitForSeconds(2);
            hitEffect.SetActive(false);
        }
    }
}