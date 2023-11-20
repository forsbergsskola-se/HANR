using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Update()
        {
            FindCursorPos();
        }

        private void FixedUpdate()
        {
            RotatePlayer();
            MoveToCursorPos();
        }

        private void FindCursorPos()
        {
            mousePosition = Input.mousePosition;
        }

        private void RotatePlayer()
        {   // where is the player looking now, where is the mouse, update looking direction
            float result = Vector3.Angle(player.transform.forward, mousePosition);
            Quaternion target = Quaternion.Euler(0, result, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            
        }
        
        private void MoveToCursorPos()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                
            }
        }

    }
}