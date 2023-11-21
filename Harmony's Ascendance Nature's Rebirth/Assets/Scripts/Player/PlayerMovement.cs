using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform player;
        private Quaternion toRotation;
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
            MouseInput();
            IsRotating();

            if (move)
            {
                MovePlayerWithNavMesh();
            }
            
        }


        private void MouseInput()
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
        }


        private void IsRotating()
        {
            if (isRotating)
            {
                RotateToClick();
                // Check if the rotation is close enough to the target rotation
                if (Quaternion.Angle(transform.rotation, toRotation) < 1f)
                {
                    Debug.Log("I stopped");
                    isRotating = false;
                    move = true;

                }
                
            }
        }
        
        private void MovePlayerWithNavMesh()
        {
            agent.speed = walkSpeed;
            agent.SetDestination(destination);
            move = false;

        }
        
        void RotateToClick()
        {
            Debug.Log("I rotated");
            Vector3 direction = (destination - transform.position).normalized;
            direction.y = 0;
            
            toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 360f);
        }
        

    }
}