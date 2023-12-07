using System;
using CustomObjects;
using Enemy;
using Player.SkillStats;
using UnityEngine;

namespace Colliders
{
    public class BubbleBeamCollider : MonoBehaviour
    {
        private Skills skill;
        private ParticleSystem ps;

        private void Start()
        {
            skill = this.gameObject.GetComponent<BubbleBeamStats>().skill;
            ps = this.gameObject.GetComponent<ParticleSystem>();
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Enemy"))
            {
                float numOfParticles = ps.emission.rateOverTime.constant * 3;
                FloatVariable health = other.GetComponent<EnemyStats>().enemyHealth;
                health.setValue(Mathf.Max(health.getValue() - (skill.damage/numOfParticles), 0));
                Debug.Log("Collided");
            }
        }
    }
}