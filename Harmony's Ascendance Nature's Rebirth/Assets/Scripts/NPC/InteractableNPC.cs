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
                        if(quest.activeBossQuest)
                            quest.questProgression.Invoke(2); //Quest goes to WalkWithMimi
                        dialogue.druidToMimi.Invoke();
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
