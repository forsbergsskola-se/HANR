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
        if (other.CompareTag("Player")) //TODO input function to interact with river
        {
            if(questUI.currentState == QuestUI.QuestLine.FindingRiverByRangerArea) //To not retrigger same quest-objective 
                questUI.questProgression.Invoke(4); //State goes to next (SaveTheRiver)
        }
    }
}
