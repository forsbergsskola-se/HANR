using System;
using CustomObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class PlayerInRangeCheck : MonoBehaviour
    {
        public BoolVariable playerInRange;
        private Vector3 playerPosition;
        [SerializeField]private GameObject player;
        [SerializeField] public float detectionRange;
        [SerializeField] public float unDetectionRange;

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
            }

            if (distance >= unDetectionRange)
            {
                playerInRange.setValue(false);
            }
        }
    }
}