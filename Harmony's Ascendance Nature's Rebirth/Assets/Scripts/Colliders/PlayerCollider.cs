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
        private RockStat rockStat;

        private void Start()
        {
            animator = this.gameObject.GetComponent<Animator>();
            rockStat = this.gameObject.GetComponent<RockStat>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Rock"))
            {
                animator.SetBool(IsHitbyRock, true);
                Health.setValue(Mathf.Max(Health.getValue() - rockStat.attackDamage,0f));
                StartCoroutine(playerStandUp(other));
            } 
        }

        private IEnumerator playerStandUp(Collision other)
        {
            yield return new WaitForSeconds(1);
            other.gameObject.SetActive(false);
            animator.SetBool(IsHitbyRock,false);
        }
    }
}