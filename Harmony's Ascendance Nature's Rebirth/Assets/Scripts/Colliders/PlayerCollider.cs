using System;
using System.Collections;
using UnityEngine;

namespace Colliders
{
    public class PlayerCollider : MonoBehaviour
    {
        private Animator animator;
        private static readonly int IsHitbyRock = Animator.StringToHash("isHitbyRock");

        private void Start()
        {
            animator = this.gameObject.GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Rock"))
            {
                animator.SetBool(IsHitbyRock, true);
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