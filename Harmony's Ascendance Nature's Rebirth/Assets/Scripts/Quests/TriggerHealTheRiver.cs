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

    public GameObject riverEffect;

    [SerializeField] private Instructions instructions;

    private bool clickable = false;
    


    private void Start()
    {
        usableItems.usedBook.AddListener(CheckBookClick);
        riverEffect.SetActive(false);
    }

    private void OnDestroy()
    {
        usableItems.usedBook.RemoveListener(CheckBookClick);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && quest.currentWaterStaffState == Quest.WaterStaffQuestLine.SaveTheRiver)
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
        riverEffect.SetActive(false);
    }

    private void CheckBookClick()
    {
        if (clickable)
        {
            SFX.SoundManager.PlaySound("River");
            riverEffect.SetActive(true);
            colourChangeWater.SaveRiver.Invoke();
            waterStaff.SetActive(true);
            instructions.buttonInput.Invoke(null);
            quest.questProgression.Invoke(5); //State goes to GettingReward
        }
    }
}