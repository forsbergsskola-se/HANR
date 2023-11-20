using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    // player position, Looking direction, 
    
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rg;
        private Vector3 Destination;
        private bool iswalking = false;
        private Vector3 mousePosition;
        private Vector3 playerDestination;
        public NavMeshAgent agent;
        [SerializeField] private float walkSpeed;

        private void Start()
        {
            rg = GetComponent<Rigidbody>();
            agent.speed = walkSpeed;
        }

        void Update()
        {
            // MovePlayer();
            MovePlayerWithNavMesh();
        }

        // private void FixedUpdate()
        // {
        //     // RotatePlayer();
        // }
        
        private void RotatePlayer()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hit = Physics.Raycast(ray, out var raycastHit);

            if (hit)
            {
                var point = raycastHit.point;
                point.y = transform.position.y;
                //Vector3 destination = Vector3.Lerp(transform.forward, point, smooth); kanske lerp för framtiden? Måste nog låsa y på något sätt med lerp
                transform.LookAt(point);
                
            }
        }

        private void click()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var raycastHit))
            {
                if (raycastHit.transform.gameObject.CompareTag("Ground"))
                {

                }
            }

        }
        private void MovePlayer()
        {
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("1");
                iswalking = true;
                
                if (Physics.Raycast(ray, out var raycastHit))
                {
                    Debug.Log("2");
                    Destination = raycastHit.point;
                    if (raycastHit.transform.gameObject.CompareTag("Ground"))
                    {
                        Debug.Log("3");
                        Vector3 targetPosition =
                            new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
                        Vector3 moveDirection = (targetPosition - transform.position).normalized;

                        rg.velocity = moveDirection * walkSpeed;
                    }
                }
            }

            Debug.Log(Destination);
            //Does not round up exactly cordinates so we checked if it was bigger after it started walking. Need to determine what direction we are walking to set the velocity to set velocity.zero when we have moved further then the destination
            if (iswalking)
            {
                //ANGLE! IT IS THE ANGLE!
                if (Destination.z > transform.position.z)
                {
                    
                }

                if (Destination.z < transform.position.z)
                {
                    
                }
            }
            
            rg.velocity = Vector3.zero;
            
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
                            Destination = raycastHit.point;
                            agent.speed = walkSpeed;
                            agent.SetDestination(Destination);
                        }
                    }
                }
                
            }
            
        }

    }
}