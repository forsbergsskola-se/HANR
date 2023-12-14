using UI;
using UnityEngine;

namespace NPC
{
    public class InteractableNPC : MonoBehaviour
    {
        public Dialogue dialogue;
        private bool playerClose;
        public GameObject thisNPC;
        private void Update()
        {
            if (playerClose)
            { 
                if (thisNPC.name == "BearMan")
                {
                    dialogue.druidToBearMan.Invoke();
                    playerClose = false;
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
