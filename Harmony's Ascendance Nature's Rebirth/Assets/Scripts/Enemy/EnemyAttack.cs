using System;
using System.Collections;
using CustomObjects;
using UnityEngine;
using UnityEngine.AI;

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
        private GameObject player;
        
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
            player = GameObject.FindWithTag("Player");
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
                GameObject  rockInstance = Instantiate(rock,enemyHand.transform.position,  enemyHand.transform.rotation);
                rockInstance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                // setRockMotion(rockInstance,  player.transform.position);
                isEnemyThrowAttack.setValue(true);
                animator.SetBool("isRangedAttack",false);
                throwStarted = true;
                Debug.Log("bla");
            }
            
        }

        private void setRockMotion(GameObject rock,  Vector3 playerPos)
        {
            Vector3 rockDir = (-rock.transform.position + playerPos).normalized;
            
        }
    }
}