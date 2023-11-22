using System;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class NPCMove : MonoBehaviour
    {
        private Transform player;
        private Quaternion toRotation;
        private Vector3 mousePosition;
        public NavMeshAgent agent;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float turnRate;
        [SerializeField] private ParticleSystem clickEffect;

        private void Start()
        {
            agent.speed = walkSpeed;
        }

        void Update()
        { 
            MouseInput();
            RotateToClick();
        }
        
        private void MouseInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (raycastHit.transform.CompareTag("Ground"))
                        {
                            agent.speed = walkSpeed;
                            agent.destination = raycastHit.point;
                            if (clickEffect != null)
                            {
                                Instantiate(clickEffect, raycastHit.point += new Vector3(0, 0.3f, 0),
                                    clickEffect.transform.rotation);
                            }
                        }
                    }
                }
            }
        }
        
        void RotateToClick()
        {
            if (agent.velocity != Vector3.zero)
            {
                Vector3 direction = agent.velocity.normalized;
                direction.y = 0;
                toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime*turnRate);
            }
        }
    }
}