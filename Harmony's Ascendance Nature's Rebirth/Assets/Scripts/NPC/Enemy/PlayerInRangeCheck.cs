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
        public BoolVariable playCombatMusicG;
        public BoolVariable playCombatMusicP;
        public BoolVariable playCombatMusicR;
        private Vector3 playerPosition;
        private GameObject player;
        [SerializeField] private float detectionRange;
        [SerializeField] private float unDetectionRange;
        [SerializeField] private float attackRange;
        [SerializeField] private GameObject CritterG;
        [SerializeField] private GameObject CritterP;
        [SerializeField] private GameObject CritterR;
        private bool changeMusic;
        

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
                playerInRange.setValue(true);
                changeMusic = true;
            }

            else if (distance >= unDetectionRange)
            {
                playerInRange.setValue(false);
                changeMusic = false;

            }
            else if (distance <= attackRange)
            {
                playerInAttackRange.setValue(true);
            }
        }

        private void CheckMusicPlaying(bool changeMusic)
        {
            if (changeMusic)
            {
                if (this.gameObject == CritterG && playCombatMusicG.getValue() == false)
                {
                    playCombatMusicG.setValue(true);
                }

                if (this.gameObject == CritterP && playCombatMusicP.getValue() == false)
                {
                    playCombatMusicP.setValue(true);
                }

                if (this.gameObject == CritterR && playCombatMusicR.getValue() == false)
                {
                    playCombatMusicR.setValue(true);
                }
            }

            if (!changeMusic)
            {
                if (this.gameObject == CritterG && playCombatMusicG.getValue())
                {
                    playCombatMusicG.setValue(false);
                }

                if (this.gameObject == CritterP && playCombatMusicP.getValue())
                {
                    playCombatMusicP.setValue(false);
                }

                if (this.gameObject == CritterR && playCombatMusicR.getValue())
                {
                    playCombatMusicR.setValue(false);
                }
            }
            
        }
    }
}