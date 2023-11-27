using System;
using CustomObjects;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject rock;
        public BoolVariable playerInEnemyRange;
        public IntVariable enemyThrowAttackCooldown;
        private GameObject enemyHand;

        private void Start()
        {
            enemyHand = this.gameObject.GetComponentInChildren<EnemyHand>().gameObject;
        }

        private void Awake()
        {
            playerInEnemyRange.ValueChanged.AddListener(startAttack);
            enemyThrowAttackCooldown.ValueChanged.AddListener(throwAttack);
        }

        private void OnDestroy()
        {
            playerInEnemyRange.ValueChanged.RemoveListener(startAttack);
            enemyThrowAttackCooldown.ValueChanged.RemoveListener(throwAttack);
        }

        private void startAttack(bool inRange)
        {
            if (inRange)
            {
                throwAttack(enemyThrowAttackCooldown.getValue());
            }
        }
        
        private void throwAttack(int cooldown)
        {
            if (cooldown == 0)
            {
                Instantiate(rock, enemyHand.transform);
                enemyThrowAttackCooldown.setValue(20);
                
            }
        }
    }
}