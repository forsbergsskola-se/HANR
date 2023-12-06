using System;
using UnityEngine;

namespace Colliders
{
    public class SkillProjectileCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}