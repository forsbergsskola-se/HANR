using System;
using System.Collections;
using CustomObjects;
using Player;
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
        private GameObject playerHead;
        private RockObjectPool rockObjectPool;
        
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
            playerHead = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerHead>().gameObject;
            rockObjectPool = this.gameObject.GetComponent<RockObjectPool>();
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
                GameObject rockInstance = rockObjectPool.GetPooledGameObject();
                if (rockInstance != null)
                {
                    rockInstance.transform.position = enemyHand.transform.position;
                    rockInstance.transform.rotation = enemyHand.transform.rotation;

                    setRockMotion(rockInstance, playerHead.transform.position);
                    isEnemyThrowAttack.setValue(true);
                    animator.SetBool("isRangedAttack", false);
                    throwStarted = true;
                }
            }
            
        }

        private void setRockMotion(GameObject rock,  Vector3 playerPos)
        {
            Vector3 rockDir = (-rock.transform.position + playerPos).normalized;
            Rigidbody rb = rock.GetComponent<Rigidbody>();
            
            rb.AddForce(new Vector3(rockDir.x * 25f, rockDir.y*25f, rockDir.z*25f),ForceMode.Impulse);
        }
    }
}