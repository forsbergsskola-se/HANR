using System;
using UnityEngine;

namespace Colliders
{
    public class CritterStingColllider : MonoBehaviour
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Get Stung");
            }
        }        
    }
}