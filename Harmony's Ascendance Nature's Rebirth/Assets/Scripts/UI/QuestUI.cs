using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UI
{
    public class QuestUI : MonoBehaviour
    {

        public enum QuestLine
        {
            TalkingToRanger,
            FindingBearMan,
            CollectingCrate, //Spawn crates inventory (potions)
            FindingRiverByRangerArea,
            SaveTheRiver,
            GettingReward, //Spawn staff
            EndQuest
        }

        public UnityEvent <int> questProgression; //Invoke this Unity-event during play-through

        public TMP_Text questTitle;
        public TMP_Text questLog;
        public QuestLine currentState;
        void Start()
        {
            currentState = QuestLine.TalkingToRanger;
            questProgression.AddListener(SetState);
        }

        private void OnDestroy()
        {
            questProgression.RemoveListener(SetState);
        }

        private void Update()
        {
            switch (currentState)
            {
                case QuestLine.TalkingToRanger: //First Objective
                    questTitle.text = "Talk to Ranger";
                    questLog.text = "¤ Ranger is most likely to reside at a camp."; //Start
                    break;
                case QuestLine.FindingBearMan: //1
                    questTitle.text = "Find and talk to the BearMan";
                    questLog.text =
                        "¤ I need to find this BearMan. But it's a big forest, he can be anywhere. Wonder if he left a teleport nearby for quicker traversal?";
                    break;
                case QuestLine.CollectingCrate: //2
                    questTitle.text = "Potion necessities";
                    questLog.text = "¤ O_O a crate! Let's collect the crates content."; //Destroy the crate + spawn items (potion)
                    break;
                case QuestLine.FindingRiverByRangerArea: //3
                    questTitle.text = "Find the river";
                    questLog.text = "¤ The river by the Rangers camp huh. I think I noticed a partly destroyed bridge as well.";
                    break;
                case QuestLine.SaveTheRiver: //4
                    questTitle.text = "Save the river!";
                    questLog.text = "¤ Heal the river.";
                    break;
                case QuestLine.GettingReward: //5
                    
                    questTitle.text = "Congratulations!";
                    questLog.text = "¤ Collect your reward"; //Spawn staff
                    break;
            }
        }
        
        void SetState(int part)
        {
            if (part == 1)
                currentState = QuestLine.FindingBearMan;
            else if (part == 2)
                currentState = QuestLine.CollectingCrate;
            else if (part == 3)
                currentState = QuestLine.FindingRiverByRangerArea;
            else if (part == 4)
                currentState = QuestLine.SaveTheRiver; // TODO trigger change environment
            else if (part == 5)
                currentState = QuestLine.GettingReward; // TODO spawn water staff
            else if (part == 6) //TODO when/where to invoke this?
                currentState = QuestLine.EndQuest;
        }
    }
}