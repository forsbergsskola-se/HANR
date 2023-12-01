using System;
using CustomObjects;
using UnityEngine;

namespace Player
{
    public class EnemiesInRange : MonoBehaviour
    {

        public BoolVariable enemyInRange;
        private Vector3 enemyPos;
        private GameObject enemy;
        [SerializeField] private float detectionRange;
        [SerializeField] private float attackRange;


        private void Start()
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        
        private void Update()
        {
            enemyPos = enemy.transform.position;
            CheckIfEnemyInRange(enemyPos);
        }

        private void CheckIfEnemyInRange(Vector3 enemyPosition)
        {
            float distance = Vector3.Distance(enemyPosition, this.transform.position);
            
            if (distance <= detectionRange)
            {
                enemyInRange.setValue(true);
            }
            else
            {
                enemyInRange.setValue(false);
            }
        }
    }
}