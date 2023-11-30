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
        public BoolVariable effectUsed;
        
        private Quaternion toRotation;
        private Vector3 moveToPoint;
        
        public NavMeshAgent agent;
        public Animator animator;
        
        [SerializeField] private float walkSpeed;
        [SerializeField] private float turnRate;
        [SerializeField] private GameObject pooledEffect;
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
            if (agent.velocity.magnitude > walkSpeed/2 && !playerAttacking)
            {
                animator.SetBool("isMoving",true);
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
                    effectUsed.setValue(true);
                }
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