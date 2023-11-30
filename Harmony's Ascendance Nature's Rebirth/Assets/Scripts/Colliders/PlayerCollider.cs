using System;
using System.Collections;
using CustomObjects;
using Enemy.BossEnemy;
using UnityEngine;

namespace Colliders
{
    public class PlayerCollider : MonoBehaviour
    {
        private Animator animator;
        private static readonly int IsHitbyRock = Animator.StringToHash("isHitbyRock");
        public FloatVariable Health;
        public CombatStatEnemyBoss combatStatEnemyBoss;
        public CombatStatEnemyCritter combatStatEnemyCritter;

        private void Awake()
        {
            Health.ValueChanged.AddListener(IsDead);
        }

        private void OnDestroy()
        {
            Health.ValueChanged.RemoveListener(IsDead);
        }

        private void IsDead(float health)
        {
            if (health == 0f)
            {
                animator.SetBool("isDead", true);
            }
        }

        private void Start()
        {
            animator = this.gameObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Rock"))
            {
                animator.SetBool(IsHitbyRock, true);
                Health.setValue(Mathf.Max(Health.getValue() - combatStatEnemyBoss.rockAttackDamage,0f));
                other.gameObject.SetActive(false);
                StartCoroutine(playerStandUp(other));
            } 
            else if (other.gameObject.CompareTag("GolemHand"))
            {
                Health.setValue(Mathf.Max(Health.getValue() - combatStatEnemyBoss.normalAttackDamage,0f));
            } 
            else if (other.gameObject.CompareTag("Sting"))
            {
                Health.setValue(Mathf.Max(Health.getValue() - combatStatEnemyCritter.normalAttackDamage,0f));
            }
        }

        private IEnumerator playerStandUp(Collider other)
        {
            yield return new WaitForSeconds(1);
            animator.SetBool(IsHitbyRock,false);
        }
    }
}