    using System;
using CustomObjects;
    using UltimateClean;
    using Unity.VisualScripting;
using UnityEngine;
    using UnityEngine.Serialization;

    namespace Enemy
{
    public class PlayerInRangeCheckR : MonoBehaviour
    {
        public BoolVariable playerInRangeOfCritterR;
        public BoolVariable playerInAttackRangeOfCritterR;
        public BoolVariable playCombatMusicR;
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

            if (distance <= detectionRange)
            {
                playerInRangeOfCritterR.setValue(true);
                playCombatMusicR.setValue(true);
            }

            else if (distance >= unDetectionRange)
            {
                playerInRangeOfCritterR.setValue(false);
                playCombatMusicR.setValue(false);
            } 
            
            if (distance <= attackRange)
            {
                playerInAttackRangeOfCritterR.setValue(true);
            }
            
            if (distance >= attackRange)
            {
                playerInAttackRangeOfCritterR.setValue(false);
            }
        }
    }
}