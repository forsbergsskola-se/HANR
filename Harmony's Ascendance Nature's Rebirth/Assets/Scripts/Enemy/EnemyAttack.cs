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
        private bool attackStarted;
        private bool throwStarted;
        
        private void Awake()
        {
            PlayerInEnemyRange.ValueChanged.AddListener(startAttack);
            isEnemyThrowAttack.ValueChanged.AddListener(setThrowValue);
        }
        
        private void OnDestroy()
        {
            PlayerInEnemyRange.ValueChanged.RemoveListener(startAttack);
            isEnemyThrowAttack.ValueChanged.RemoveListener(setThrowValue);

        }
            
        private void Start()
        {
            enemyHand = this.gameObject.GetComponentInChildren<EnemyHand>().gameObject;
            animator = this.gameObject.GetComponentInChildren<Animator>();
        }
        
        private void startAttack(bool inRange)
        {
            if (inRange && ! attackStarted)
            {
                attackStarted = true;
                animator.SetBool("isRangedAttack",true);
            }
            else if(!inRange)
            {
                animator.SetBool("isRangedAttack",false);
                attackStarted = false;
            }
        }

        private void setThrowValue(bool throwVal)
        {
            throwStarted = throwVal;
        }
        
        public void throwAttack()
        {
            if (!throwStarted)
            {
                Instantiate(rock, enemyHand.transform);
                isEnemyThrowAttack.setValue(true);
                animator.SetBool("isRangedAttack",false);
                throwStarted = true;
            }
            
        }
    }
}