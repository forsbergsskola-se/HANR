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
        private bool isRotating = false;
        

        private void Start()
        {
            agent.speed = walkSpeed;
        }

        void Update()
        {
            RotateTowards(destination);
            
            if (isRotating)
            {
                // Check if the rotation is close enough to the target rotation
                if (Quaternion.Angle(transform.rotation, agent.transform.rotation) < 5f)
                {
                    // Stop rotating when close enough
                    isRotating = false;

                    // Set the destination for the NavMeshAgent
                    MovePlayerWithNavMesh();
                }
            }
            
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
                        RotateTowards(destination);
                        
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
        
        void RotateTowards(Vector3 targetPosition)
        {
            isRotating = true;
            
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Keep the rotation only in the horizontal plane
            
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 1000f);
        }
        

    }
}