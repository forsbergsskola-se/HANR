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
                SFX.SoundManager.PlaySound("Get hit");
                StartCoroutine(playerStandUp(other));
            } 
            else if (other.gameObject.CompareTag("GolemHand"))
            {
                Health.setValue(Mathf.Max(Health.getValue() - combatStatEnemyBoss.normalAttackDamage,0f));
                animator.SetBool("isHit", true);
                SFX.SoundManager.PlaySound("Get hit");
            } 
            else if (other.gameObject.CompareTag("Sting"))
            {
                Health.setValue(Mathf.Max(Health.getValue() - combatStatEnemyCritter.normalAttackDamage,0f));
                animator.SetBool("isHit", true);
                SFX.SoundManager.PlaySound("Get hit");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("GolemHand"))
            {
                animator.SetBool("isHit", false);
            } 
            else if (other.gameObject.CompareTag("Sting"))
            {
                animator.SetBool("isHit", false);
            }        }

        private IEnumerator playerStandUp(Collider other)
        {
            yield return new WaitForSeconds(1);
            animator.SetBool(IsHitbyRock,false);
        }
    }
}