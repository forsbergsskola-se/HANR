using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TriggerHealTheRiver : MonoBehaviour
{
    public Quest quest;
    
    public GameObject waterStaff;

    [SerializeField] private Instructions instructions;
    
    private void Start()
    {
        instructions = FindObjectOfType<Instructions>().GetComponent<Instructions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instructions.gameObject.SetActive(true);
            instructions.buttonInput.Invoke("Interact");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.FindingRiverByRangerArea)
        {
            quest.questProgression.Invoke(4); //State goes to next (SaveTheRiver)
        }
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.SaveTheRiver)
            {
                instructions.gameObject.SetActive(false);
                waterStaff.SetActive(true);
                quest.questProgression.Invoke(5); //State goes to next (Getting Reward)
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.GettingReward)
            quest.questProgression.Invoke(6);
        instructions.gameObject.SetActive(false);
    }
}
