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
            TalkToBearMan,
            CollectingCrate, //Spawn crates inventory (potions)
            FindingRiverByRangerArea,
            SaveTheRiver,
            GettingReward //Spawn staff
        }

        public UnityEvent <int> questProgression; //Invoke this Unity-event during play-through

        public TMP_Text questTitle;
        public TMP_Text questLog;
        private QuestLine currentState;
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
                case QuestLine.TalkingToRanger:
                    questTitle.text = "Talk to Ranger";
                    questLog.text = "¤ Ranger is most likely to reside at a camp."; //Start
                    break;
                case QuestLine.FindingBearMan:
                    questTitle.text = "Find and talk to the BearMan";
                    questLog.text =
                        "¤ I need to find this BearMan. But it's a big forest, he can be anywhere. Wonder if he left a teleport nearby for quicker traversal?";
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
        
        void SetState(int part)
        {
            if (part == 1)
                currentState = QuestLine.FindingBearMan;
            else if (part == 2)
                currentState = QuestLine.TalkToBearMan;
            else if (part == 3)
                currentState = QuestLine.CollectingCrate;
            else if (part == 4)
                currentState = QuestLine.FindingRiverByRangerArea;
            else if (part == 5)
                currentState = QuestLine.SaveTheRiver;
            else if (part == 6)
                currentState = QuestLine.GettingReward;
        }
    }
}