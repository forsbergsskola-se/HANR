    using System;
using CustomObjects;
    using UltimateClean;
    using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class PlayerInRangeCheck : MonoBehaviour
    {
        public BoolVariable playerInRange;
        public BoolVariable playerInAttackRange;
        public BoolVariable playCombatMusic;
        private Vector3 playerPosition;
        private GameObject player;
        [SerializeField] private float detectionRange;
        [SerializeField] private float unDetectionRange;
        [SerializeField] private float attackRange;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            playerPosition = player.transform.position;
            checkIfPlayerInRange(playerPosition);
        }
        

        private void checkIfPlayerInRange(Vector3 playerPosition)
        {
            float distance = Vector3.Distance(playerPosition, this.transform.position);

            if (distance <= detectionRange && playCombatMusic.getValue() == false)
            {
                playerInRange.setValue(true);
                playCombatMusic.setValue(true);
            }

            if (distance >= unDetectionRange && playCombatMusic.getValue())
            {
                playerInRange.setValue(false);
                playCombatMusic.setValue(false);
            }

            if (distance <= attackRange)
            {
                playerInAttackRange.setValue(true);
            }
            else
            {
                playerInAttackRange.setValue(false);
            }
        }
    }
}