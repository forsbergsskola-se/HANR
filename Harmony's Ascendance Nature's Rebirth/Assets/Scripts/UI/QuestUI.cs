using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class QuestUI : MonoBehaviour
{
    
    public enum QuestLine
    {
        TalkingToRanger,
        FindingBearMan,
        TalkToBearMan,
        CollectingCrate, //Spawn crates inventory (potions)
        FindingRiverByRangerArea,
        SaveTheRiver,
        GettingReward //Spawn staff
    }

    public UnityEvent QuestProgression; //Invoke this Unity-event during play-through

    public TMP_Text questLog;
    private QuestLine currentState;
    private int questCounter;

    void Start()
    {
        currentState = QuestLine.TalkingToRanger;
        QuestProgression.AddListener(SetState);
    }

    private void OnDestroy()
    {
        QuestProgression.RemoveListener(SetState);
    }

    private void Update()
    {
        switch (currentState)
        {
            case QuestLine.TalkingToRanger:
                questLog.text = "Talk to Ranger."; //Implement text here for UI
                break;
            case QuestLine.FindingBearMan:
                questLog.text = "Find the BearMan."; //Implement text here for UI
                break;
            case QuestLine.TalkToBearMan:
                questLog.text = "Talk to BearMan."; //Implement text here for UI
                break;
            case QuestLine.CollectingCrate:
                questLog.text = "Collect the crates content."; //Destroy the crate + spawn items (potion)
                break;
            case QuestLine.FindingRiverByRangerArea:
                questLog.text = "Go to the rived by the Ranger area."; //Implement text here for UI
                break;
            case QuestLine.SaveTheRiver:
                questLog.text = "Heal the river."; //Implement text here for UI
                break;
            case QuestLine.GettingReward:
                questLog.text = "Collect your reward"; //Spawn staff
                break;
        }
    }


    void SetState()
    {
        questCounter++;
        if (questCounter == 1)
            currentState = QuestLine.FindingBearMan;
        else if (questCounter == 2)
            currentState = QuestLine.TalkToBearMan;
        else if (questCounter == 3)
            currentState = QuestLine.CollectingCrate;
        else if (questCounter == 4)
            currentState = QuestLine.FindingRiverByRangerArea;
        else if (questCounter == 5)
            currentState = QuestLine.SaveTheRiver;
        else if (questCounter == 6)
            currentState = QuestLine.GettingReward;
    }
}