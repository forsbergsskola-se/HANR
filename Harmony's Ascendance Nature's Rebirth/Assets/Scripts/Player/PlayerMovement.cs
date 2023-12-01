using System;
using CustomObjects;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public BoolVariable playerMoving;
        public BoolVariable playerAttacking;
        public TargetPoint targetPoint;
        
        private Quaternion toRotation;
        private Vector3 moveToPoint;
        
        public NavMeshAgent agent;
        public Animator animator;
        
        [SerializeField] private float walkSpeed;
        [SerializeField] private float turnRate;
        private ClickEffectPool clickEffectPool;
        
        
        private void Awake()
        {
            playerMoving.ValueChanged.AddListener(MoveToClick);
        }

        private void OnDestroy()
        {
            playerMoving.ValueChanged.RemoveListener(MoveToClick);
        }

        private void Start()
        {
            agent.speed = walkSpeed;
            clickEffectPool = this.gameObject.GetComponent<ClickEffectPool>();
        }

        private void Update()
        {
            RotateToClick();
        }

        void LateUpdate() 
        {
            
            if (agent.hasPath)
            {
                if (agent.velocity.magnitude > 0)
                {
                    animator.SetBool("isMoving",true);
                    animator.SetBool("isInAttackRange",false);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            
        }

        private void MoveToClick(bool playerMoving)
        {
            if (playerMoving && !animator.GetBool("isHitbyRock")) 
            {
                moveToPoint = targetPoint.GetValue(); 
                
                agent.speed = walkSpeed;
                agent.destination = moveToPoint;
                
                
                GameObject effectInstance = clickEffectPool.GetPooledEffects();
                if (effectInstance != null)
                {
                    effectInstance.transform.position = moveToPoint += new Vector3(0,0.3f,0);
                }
            } else if (animator.GetBool("isHitbyRock"))
            {
                agent.velocity = new Vector3(0f,0f,0f);
            }
        }
        
        private void RotateToClick() //I put this method in Update for now/ Mandel
        {
            if (agent.velocity.magnitude > 0.01f && agent.hasPath)
            {
                Vector3 direction = agent.velocity.normalized;
                direction.y = 0;
                toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime*turnRate);
            }
            else if(agent.remainingDistance < 0.05f && agent.hasPath)
            {
                transform.rotation = toRotation;
            }
        }
    }
}