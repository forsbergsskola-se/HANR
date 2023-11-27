using System;
using CustomObjects;
using UnityEngine;

namespace Enemy
{
    public class CooldownTracker : MonoBehaviour
    {
        public IntVariable enemyThrowAttackCooldown;
        private float enemyThrowAttackCooldownValue = 0f;

        private void Awake()
        {
            enemyThrowAttackCooldown.ValueChanged.AddListener(countdown);
        }
        
        private void OnDestroy()
        {
            enemyThrowAttackCooldown.ValueChanged.RemoveListener(countdown);
        }

        private void countdown(int cd)
        {
            
        }
    }
}