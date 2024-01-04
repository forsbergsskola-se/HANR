    using System;
using CustomObjects;
    using UltimateClean;
    using Unity.VisualScripting;
using UnityEngine;
    using UnityEngine.Serialization;

    namespace Enemy
{
    public class PlayerInRangeCheck : MonoBehaviour
    {
        public BoolVariable playerInRange;
        public BoolVariable playerInAttackRange;
        private Vector3 playerPosition;
        private GameObject player;
        [SerializeField] private GameObject healthBar;
        [SerializeField] private float detectionRange;
        [SerializeField] private float unDetectionRange;
        [SerializeField] private float attackRange;
        
        
        

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            healthBar.SetActive(false);
        }

        private void Update()
        {
            playerPosition = player.transform.position;
            checkIfPlayerInRange(playerPosition);
        }
        

        private void checkIfPlayerInRange(Vector3 playerPosition)
        {
            float distance = Vector3.Distance(playerPosition, this.transform.position);

            if (distance <= detectionRange)
            {
                playerInRange.setValue(true);
                healthBar.SetActive(true);
            }

            else if (distance >= unDetectionRange)
            {
                playerInRange.setValue(false);
                healthBar.SetActive(false);
            }
            else if (distance <= attackRange)
            {
                playerInAttackRange.setValue(true);
            }
        }
    }
}