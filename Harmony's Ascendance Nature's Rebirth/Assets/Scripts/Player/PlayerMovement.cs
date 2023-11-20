using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    // player position, Looking direction, 
    
    public class PlayerMovement : MonoBehaviour
    {
        private GameObject player;
        
    
      void Start()
      {
          player = GameObject.FindWithTag("Player");
      }

    
      void Update()
      {
        
      } 
    }
}