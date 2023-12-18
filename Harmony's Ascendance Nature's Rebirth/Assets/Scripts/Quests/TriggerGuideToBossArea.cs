using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class TriggerGuideToBossArea : MonoBehaviour
{
    public Quest quest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (quest.activeBossQuest) //Checking if quest is active
            {
                quest.questProgression.Invoke(2); //Activate second state in Boss Quest-Line
                
            }
        }
    }
}
