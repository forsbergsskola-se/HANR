using System;
using System.Collections;
using CustomObjects;
using Player;
using UnityEngine;

namespace BossEnemy
{
    public class EnemyAttackBossEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject rock;
        public BoolVariable isEnemyThrowAttack;
        public BoolVariable PlayerInEnemyRange;
        public BoolVariable PlayerInAttackRange;
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
            PlayerInAttackRange.ValueChanged.AddListener(meeleAttack);
        }
        
        private void OnDestroy()
        {
            PlayerInEnemyRange.ValueChanged.RemoveListener(startAttack);
            isEnemyThrowAttack.ValueChanged.RemoveListener(setThrowValue);
            PlayerInAttackRange.ValueChanged.RemoveListener(meeleAttack);

        }

        private void meeleAttack(bool inRange)
        {
            animator.SetBool("isInAttackRange",inRange);
        }
            
        private void Start()
        {
            enemyHand = this.gameObject.GetComponentInChildren<HandBossEnemy>().gameObject;
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
            Vector3 rockDir = (-rock.transform.position + playerPos);
            Rigidbody rb = rock.GetComponent<Rigidbody>();
            float height = Mathf.Abs(rockDir.y);
            float Vx = rockDir.x * Mathf.Sqrt(-Physics.gravity.y / (2 * height));
            float Vz = rockDir.z * Mathf.Sqrt(-Physics.gravity.y / (2 * height));
            

            rb.velocity = new Vector3(Vx*2f, 0, Vz*2f);

            // rb.AddForce(new Vector3(rockDir.x * 25f, rockDir.y*25f, rockDir.z*25f),ForceMode.Impulse);
        }
    }
}