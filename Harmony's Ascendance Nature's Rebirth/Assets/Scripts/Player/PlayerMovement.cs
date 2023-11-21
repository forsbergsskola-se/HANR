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
        private bool move = false;
        

        private void Start()
        {
            agent.speed = walkSpeed;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (raycastHit.transform.CompareTag("Ground"))
                        {
                            destination = raycastHit.point;
                            isRotating = true;

                        }
                    }
                }
                
            }
            
            if (isRotating)
            {
                RotateTowards(destination);
                // Check if the rotation is close enough to the target rotation
                if (Quaternion.Angle(transform.rotation, agent.transform.rotation) < 1f)
                {
                    Debug.Log("I stopped");
                    isRotating = false;
                    move = true;

                }
                
            }

            if (move)
            {
                MovePlayerWithNavMesh();
            }
            
        }
        
        
        private void MovePlayerWithNavMesh()
        {
            agent.speed = walkSpeed;
            agent.SetDestination(destination);
            move = false;

        }
        
        void RotateTowards(Vector3 targetPosition)
        {
            isRotating = true;
            Debug.Log("I rotated");
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Keep the rotation only in the horizontal plane
            
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 1000f);
        }
        

    }
}