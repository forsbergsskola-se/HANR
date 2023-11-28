using System;
using System.Collections;
using CustomObjects;
using UnityEngine;

namespace Enemy
{
    public class CooldownTracker : MonoBehaviour
    {
        public BoolVariable isEnemyThrowAttack;
        private float enemyThrowAttackCooldownValue = 10f;
        private bool timerStarted = false;
        private Animator animator;

        private void Start()
        {
            animator = this.gameObject.GetComponentInChildren<Animator>();
        }

        private void Awake()
        {
            isEnemyThrowAttack.ValueChanged.AddListener(countdown);
        }
        
        private void OnDestroy()
        {
            isEnemyThrowAttack.ValueChanged.RemoveListener(countdown);
        }

        private void countdown(bool isAttack)
        {
            if (isAttack && !timerStarted)
            {
                StartCoroutine(Timer(enemyThrowAttackCooldownValue));
            }
        }

        private IEnumerator Timer(float cooldownValue)
        {
            timerStarted = true;
            float timer = cooldownValue;
            
            while (timer > 0f)
            {
                yield return new WaitForSeconds(1f);
                timer -= 1f;
                Debug.Log("Time remaining: " + timer.ToString("0"));
            }
            
            Debug.Log("Timer finished");
            timerStarted = false;
            isEnemyThrowAttack.setValue(false);
            animator.SetBool("isRangedAttack",true);
        }
    }
}