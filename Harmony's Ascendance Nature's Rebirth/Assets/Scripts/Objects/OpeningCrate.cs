using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class OpeningCrate : MonoBehaviour
{
    public GameObject [] itemInside = new GameObject [3];
    public Quest quest;
    private bool close;

    [SerializeField] private Instructions instructions;
    

    private void Update()
    {
        if (close && Input.GetKeyDown(KeyCode.G) && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.CollectingCrate)
        {
            Vector3 offsetstart = new Vector3(-0.5f, 0.25f, 0);
            for (int slot = 0; slot < 3; slot++)
            {


                offsetstart += new Vector3(0.5f, 0, 0);
                Debug.Log(offsetstart);

                Instantiate(itemInside[slot], transform.position + offsetstart, itemInside[slot].transform.rotation);
            }

            Destroy(gameObject);
            instructions.gameObject.SetActive(false);
            if (quest.currentWaterStaffState ==
                Quest.WaterStaffQuestLine.CollectingCrate) //To not retrigger same quest-objective 
                quest.questProgression.Invoke(3); //State goes to next (FindingRiverByRangerArea)
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.CollectingCrate)
        {
            close = true;
            instructions.gameObject.SetActive(true);
            instructions.buttonInput.Invoke("Interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        close = false;
        instructions.gameObject.SetActive(false);
    }

 
}
