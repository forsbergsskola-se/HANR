using CustomObjects;
using NPC.Slime;
using UI;
using UnityEngine;

namespace NPC
{
    public class InteractableNPC : MonoBehaviour
    {
        public Dialogue dialogue;
        private bool playerClose;
        public GameObject thisNPC;
        public Quest quest;
        public BoolVariable slimeMoving;
        private void Update()
        {
            if (playerClose)
            {
                switch (thisNPC.name)
                {
                    case "BearMan":
                        dialogue.druidToBearMan.Invoke();
                        if(quest.currentWaterStaffState == Quest.WaterStaffQuestLine.FindingBearMan)
                            quest.questProgression.Invoke(2);
                        playerClose = false;
                        break;
                    case "Ranger":
                        dialogue.druidToRanger.Invoke();
                        playerClose = false;
                        break;
                    case "Mimi":
                        if (quest.activeBossQuest && quest.currentBossState == Quest.BossQuestLine.InteractWithMimi)
                        {
                            quest.questProgression.Invoke(2); //Quest goes to WalkWithMimi
                            slimeMoving.setValue(true);
                        }

                        if (quest.currentBossState == Quest.BossQuestLine.WalkWithMimiToBoss)
                        {
                            slimeMoving.setValue(true);
                        }
                        break;
                }
            }
        }
       

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerClose = true;
                Debug.Log("Player close");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerClose = false;
                 Debug.Log("Walk away");
            }
        }
    }
}
