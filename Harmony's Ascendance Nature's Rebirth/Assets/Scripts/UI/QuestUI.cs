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

    public TMP_Text questTitle;
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
                questTitle.text = "Talk to Ranger";
                questLog.text = "¤ Ranger is most likely to reside at a camp."; //Start
                break;
            case QuestLine.FindingBearMan:
                questTitle.text = "Find and talk to the BearMan";
                questLog.text = "¤ The ranger was in panic, and asked me to find this BearMan. But it's a big forest, he can be anywhere. Wonder if he left a teleport nearby for quicker traversal?";
                break;
            case QuestLine.TalkToBearMan:
                questTitle.text = "Talk to BearMan";
                questLog.text = "";
                break;
            case QuestLine.CollectingCrate:
                questTitle.text = "Potion necessities";
                questLog.text = "Collect the crates content."; //Destroy the crate + spawn items (potion)
                break;
            case QuestLine.FindingRiverByRangerArea:
                questTitle.text = "Find the river";
                questLog.text = "Go to the river by the Rangers camp.";
                break;
            case QuestLine.SaveTheRiver:
                questTitle.text = "Save the river!";
                questLog.text = "Heal the river.";
                break;
            case QuestLine.GettingReward:
                questTitle.text = "Congratulations!";
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