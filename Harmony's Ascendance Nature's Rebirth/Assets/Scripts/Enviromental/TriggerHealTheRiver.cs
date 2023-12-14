using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class TriggerHealTheRiver : MonoBehaviour
{
    public QuestUI questUI;

    public GameObject waterStaff;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && questUI.currentState == QuestUI.QuestLine.FindingRiverByRangerArea)
        {
            questUI.questProgression.Invoke(4); //State goes to next (SaveTheRiver)
        }
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            if (questUI.currentState == QuestUI.QuestLine.SaveTheRiver)
            {
                waterStaff.SetActive(true);
                questUI.questProgression.Invoke(5); //State goes to next (Getting Reward)
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && questUI.currentState == QuestUI.QuestLine.GettingReward)
            questUI.questProgression.Invoke(6);
    }
}
