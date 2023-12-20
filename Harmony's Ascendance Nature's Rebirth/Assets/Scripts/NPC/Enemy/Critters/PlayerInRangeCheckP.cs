    using System;
using CustomObjects;
    using UltimateClean;
    using Unity.VisualScripting;
using UnityEngine;
    using UnityEngine.Serialization;

    namespace Enemy
{
    public class PlayerInRangeCheckP : MonoBehaviour
    {
        public BoolVariable playerInRangeOfCritterP;
        public BoolVariable playerInAttackRangeOfCritterP;
        public BoolVariable playCombatMusicP;
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
                playerInRangeOfCritterP.setValue(true);
                playCombatMusicP.setValue(true);
                healthBar.SetActive(true);
            }

            else if (distance >= unDetectionRange)
            {
                playerInRangeOfCritterP.setValue(false);
                playCombatMusicP.setValue(false);
                healthBar.SetActive(false);
            }
            
            if (distance <= attackRange)
            {
                playerInAttackRangeOfCritterP.setValue(true);
            }
            
            if (distance >= attackRange)
            {
                playerInAttackRangeOfCritterP.setValue(false);
            }
        }
    }
}