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

    public UsableItems usableItems;

    public ShaderColourChange colourChangeWater;
    
    public GameObject waterStaff;

    [SerializeField] private Instructions instructions;

    private bool clickable = false;
    


    private void Start()
    {
        colourChangeWater.SaveRiver.Invoke();

        usableItems.usedBook.AddListener(CheckBookClick);
    }

    private void OnDestroy()
    {
        usableItems.usedBook.RemoveListener(CheckBookClick);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructions.gameObject.SetActive(true);
            instructions.buttonInput.Invoke("River");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.FindingRiverByRangerArea)
        {
            quest.questProgression.Invoke(4); //State goes to next (SaveTheRiver)
        }

        if (other.CompareTag("Player"))
        {
            if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.SaveTheRiver)
            {
                clickable = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        clickable = false;
        if(other.CompareTag("Player") && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.GettingReward)
            quest.questProgression.Invoke(6);
        instructions.gameObject.SetActive(false);
    }

    private void CheckBookClick()
    {
        if (clickable)
        {
            SFX.SoundManager.PlaySound("River");
            Debug.Log("we click");
            colourChangeWater.SaveRiver.Invoke();
            waterStaff.SetActive(true);
            quest.questProgression.Invoke(5); 
        }
    }
}