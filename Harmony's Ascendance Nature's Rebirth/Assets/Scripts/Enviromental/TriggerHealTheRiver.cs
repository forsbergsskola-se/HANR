using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class TriggerHealTheRiver : MonoBehaviour
{
    public QuestUI questUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && questUI.currentState == QuestUI.QuestLine.FindingRiverByRangerArea)
        { 
            questUI.questProgression.Invoke(4); //State goes to next (SaveTheRiver)
        }
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            questUI.questProgression.Invoke(5); //State goes to next (Getting Reward)
            
            //TODO trigger changing environment (water changes color) + spawn Water Staff
        }
    }
}
