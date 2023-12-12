using UI;
using UnityEngine;

namespace NPC
{
    public class InteractableNPC : MonoBehaviour
    {
        public Dialogue dialogue;
        private bool playerClose;
        public GameObject thisNPC;
        public QuestUI questUI;
        private void Update()
        {
            if (playerClose)
            { 
                if (thisNPC.name == "BearMan")
                {
                    dialogue.druidToBearMan.Invoke();
                    playerClose = false;
                    if(questUI.currentState == QuestUI.QuestLine.FindingBearMan) //To not retrigger same quest-objective 
                        questUI.questProgression.Invoke(2); //State goes to next (CollectingCrate)
                }
                if (thisNPC.name == "Ranger")
                {
                    dialogue.druidToRanger.Invoke();
                    playerClose = false;
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
