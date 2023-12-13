using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class TriggerHealTheRiver : MonoBehaviour
{
    public QuestUI questUI;
    public PropertyColourChange propertyColourChange;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && questUI.currentState == QuestUI.QuestLine.FindingRiverByRangerArea)
        { 
            questUI.questProgression.Invoke(4); //State goes to next (SaveTheRiver)
        }
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            propertyColourChange.SaveRiver.Invoke();
            
            questUI.questProgression.Invoke(5); //State goes to next (Getting Reward)
            //TODO spawn Water Staff
        }
    }
}
