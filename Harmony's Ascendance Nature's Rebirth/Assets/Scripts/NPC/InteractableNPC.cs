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
                    Debug.Log("Talking to Bearman");
                    questUI.questProgression.Invoke(2);
                }
                if (thisNPC.name == "Ranger")
                {
                    dialogue.druidToRanger.Invoke();
                    playerClose = false;
                    Debug.Log("Talking to Ranger");
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
