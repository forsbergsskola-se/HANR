using System;
using CustomObjects;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject rock;
        public BoolVariable isEnemyThrowAttack;
        private GameObject enemyHand;
            
        private void Start()
        {
            enemyHand = this.gameObject.GetComponentInChildren<EnemyHand>().gameObject;
        }
        
        public void throwAttack()
        {
            if (!isEnemyThrowAttack)
            {
                Instantiate(rock, enemyHand.transform);
                isEnemyThrowAttack.setValue(true);
            }
        }
    }
}