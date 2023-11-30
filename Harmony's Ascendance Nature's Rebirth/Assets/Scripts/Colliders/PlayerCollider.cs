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
        }

        private IEnumerator playerStandUp(Collider other)
        {
            yield return new WaitForSeconds(1);
            animator.SetBool(IsHitbyRock,false);
        }
    }
}