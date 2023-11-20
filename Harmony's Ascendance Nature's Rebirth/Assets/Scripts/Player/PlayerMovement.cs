using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    // player position, Looking direction, 
    
    public class PlayerMovement : MonoBehaviour
    {
        private GameObject player;
        private Vector3 mousePosition;
        private Vector3 playerDestination;
        [SerializeField] private float smooth;
        
        
    
        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        private void FixedUpdate()
        {
            RotatePlayer1();
        }
        
        private void RotatePlayer1()
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

    }
}