using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform player;
        private Vector3 destination;
        private Vector3 mousePosition;
        public NavMeshAgent agent;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float turnRate;
        [SerializeField] private Quaternion targetRotation = Quaternion.identity;

        private void Start()
        {
            agent.speed = walkSpeed;
        }

        void Update()
        {
            RotateTowards(destination);
            MovePlayerWithNavMesh();
        }
        
        void RotateTowards(Vector3 targetPosition)
        {
            // Calculate the direction to the target
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Keep the rotation only in the horizontal plane

            // Rotate towards the target
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 1000f);
        }
        
        
        private void MovePlayerWithNavMesh()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (raycastHit.transform.CompareTag("Ground"))
                        {
                            destination = raycastHit.point;
                            agent.speed = walkSpeed;
                            agent.SetDestination(destination);
                        }
                    }
                }
                
            }
            
        }

    }
}