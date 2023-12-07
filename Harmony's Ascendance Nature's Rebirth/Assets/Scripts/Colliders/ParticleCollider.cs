using System;
using UnityEngine;

namespace Colliders
{
    public class ParticleCollider : MonoBehaviour
    {
        private int numberOfColliders = 0; 
        private void OnParticleCollision(GameObject other)
        {
            numberOfColliders = numberOfColliders + 1;
            Debug.Log(numberOfColliders);
        }
    }
}