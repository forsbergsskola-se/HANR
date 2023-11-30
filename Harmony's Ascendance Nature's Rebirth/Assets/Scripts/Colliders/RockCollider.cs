using System.Collections;
using UnityEngine;

namespace Colliders
{
    public class RockCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                this.gameObject.SetActive(false);
            } 
        }
    }
}