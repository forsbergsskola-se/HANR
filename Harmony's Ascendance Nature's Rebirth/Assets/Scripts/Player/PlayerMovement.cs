using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    // player position, Looking direction, 
    
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rg;
        private Vector3 mousePosition;
        private Vector3 playerDestination;
        [SerializeField] private float walkDistance;
        [SerializeField] private float smooth;


        private void Start()
        {
            rg = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("MOVE!");
                MovePlayer();
            }
        }

        private void FixedUpdate()
        {
            RotatePlayer();
        }
        
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

        private void MovePlayer()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var raycastHit))
            { 
                if (raycastHit.transform.gameObject.CompareTag("Ground"))
                {
                    rg.velocity = Vector3.MoveTowards(transform.position, raycastHit.point, walkDistance * Time.deltaTime);

                }
                
            }
            

        }

    }
}