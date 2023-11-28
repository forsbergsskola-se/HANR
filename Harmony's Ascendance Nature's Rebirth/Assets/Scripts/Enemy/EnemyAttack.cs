using System;
using CustomObjects;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject rock;
        public BoolVariable isEnemyThrowAttack;
        public BoolVariable PlayerInEnemyRange;
        private GameObject enemyHand;
        private Animator animator;
        
        private void Awake()
        {
            PlayerInEnemyRange.ValueChanged.AddListener(startAttack);
            isEnemyThrowAttack.ValueChanged.AddListener(ongoingAttack);
        }
        
        private void OnDestroy()
        {
            PlayerInEnemyRange.ValueChanged.RemoveListener(startAttack);
            isEnemyThrowAttack.ValueChanged.RemoveListener(ongoingAttack);

        }
            
        private void Start()
        {
            enemyHand = this.gameObject.GetComponentInChildren<EnemyHand>().gameObject;
            animator = this.gameObject.GetComponentInChildren<Animator>();
        }
        
        private void startAttack(bool inRange)
        {
            if (inRange)
            {
                animator.SetBool("isRangedAttack",true);
            }
            else
            {
                animator.SetBool("isRangedAttack",false);
            }
        }
        
        private void ongoingAttack(bool isAttack)
        {
            if (!isAttack)
            {
                animator.SetBool("isRangedAttack",true);
            }
            else
            {
                animator.SetBool("isRangedAttack",false);
            }
        }
        
        public void throwAttack()
        {
            Debug.Log(isEnemyThrowAttack.getValue());
            if (isEnemyThrowAttack.getValue()  == false)
            {
                Instantiate(rock, enemyHand.transform);
                // isEnemyThrowAttack.setValue(true);
            }
        }
    }
}