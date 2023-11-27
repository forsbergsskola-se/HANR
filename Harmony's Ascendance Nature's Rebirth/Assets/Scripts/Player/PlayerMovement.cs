using System;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform player;
        private Quaternion toRotation;
        private Vector3 mousePosition;
        public NavMeshAgent agent;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float turnRate;
        [SerializeField] private ParticleSystem clickEffect;
        [SerializeField] private float clickEffectDuration = 1.0f;
        public Animator animator;

        private void Start()
        {
            agent.speed = walkSpeed;
        }

        void LateUpdate()
        {
            if (agent.velocity.magnitude > walkSpeed/2)
            {
                animator.SetBool("isMoving",true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            //MouseInput();
            ClickCheck clickCheck = GetComponent<ClickCheck>();
            MoveToClick(clickCheck.rayHit);
            RotateToClick();
        }

        private void MoveToClick(RaycastHit raycastHit)
        {
            agent.speed = walkSpeed;
            agent.destination = raycastHit.point;
            if (clickEffect != null)
            {
                ParticleSystem instantiatedEffect =  Instantiate(clickEffect, raycastHit.point += new Vector3(0, 0.3f, 0),
                    clickEffect.transform.rotation);
                Destroy(instantiatedEffect.gameObject, clickEffectDuration);
            }
        }
        
        private void MouseInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("M1");
                if (Camera.main != null)
                {
                    Debug.Log("Yes Cam");
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (raycastHit.transform.CompareTag("Ground"))
                        {
                            agent.speed = walkSpeed;
                            agent.destination = raycastHit.point;
                            if (clickEffect != null)
                            {
                                ParticleSystem instantiatedEffect =  Instantiate(clickEffect, raycastHit.point += new Vector3(0, 0.3f, 0),
                                    clickEffect.transform.rotation);
                                Destroy(instantiatedEffect.gameObject, clickEffectDuration);
                            }
                        }
                    }
                }
            }
        }
        
        void RotateToClick()
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