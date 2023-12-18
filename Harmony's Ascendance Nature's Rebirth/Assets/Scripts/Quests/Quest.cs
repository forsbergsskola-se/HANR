using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


namespace UI
{
    public class Quest : MonoBehaviour
    {
        public enum WaterStaffQuestLine
        {
            TalkingToRanger,
            FindingBearMan,
            CollectingCrate, //Spawn crates inventory (potions)
            FindingRiverByRangerArea,
            SaveTheRiver,
            GettingReward, //Spawn staff
            GoBackToRanger,
            EndQuest
        }
        
        public enum BossQuestLine
        {
            TalkToSlime,
            FindBossArea,
            DefeatBoss,
            ReturnToRanger
        }

        public bool activeWaterStaffQuest;
        public bool activeBossQuest;
        
        public UnityEvent <int> questProgression; //Invoke this Unity-event during play-through

        public TMP_Text questTitle;
        public TMP_Text questLog;
        public WaterStaffQuestLine currentWaterStaffState;
        public BossQuestLine currentBossState;
        void Start()
        {
            activeWaterStaffQuest = true;
            currentWaterStaffState = WaterStaffQuestLine.TalkingToRanger;
            questProgression.AddListener(SetState);
        }

        private void OnDestroy()
        {
            questProgression.RemoveListener(SetState);
        }

        private void Update() //Quest Title + Quest Text (Guide)
        {
            if (activeWaterStaffQuest)
            {
                switch (currentWaterStaffState)
                {
                    case WaterStaffQuestLine.TalkingToRanger: //First Objective
                        questTitle.text = "Talk to Ranger";
                        questLog.text = "¤ Ranger is most likely to reside at a camp."; //Start
                        break;
                    case WaterStaffQuestLine.FindingBearMan: //1
                        questTitle.text = "Find and Talk To the BearMan";
                        questLog.text =
                            "¤ I need to find this BearMan. But it's a big forest, he can be anywhere. Wonder if he left a teleport nearby for quicker traversal?";
                        break;
                    case WaterStaffQuestLine.CollectingCrate: //2
                        questTitle.text = "Potion Necessities";
                        questLog.text =
                            "¤ O_O a crate! Let's collect the crates content."; //Destroy the crate + spawn items (potion)
                        break;
                    case WaterStaffQuestLine.FindingRiverByRangerArea: //3
                        questTitle.text = "Find The River";
                        questLog.text =
                            "¤ The river by the Rangers camp huh. I think I noticed a partly destroyed bridge as well.";
                        break;
                    case WaterStaffQuestLine.SaveTheRiver: //4 //TODO Invoke changing water script
                        questTitle.text = "Save The River!";
                        questLog.text = "¤ Heal the river.";
                        break;
                    case WaterStaffQuestLine.GettingReward: //5
                        questTitle.text = "Congratulations!";
                        questLog.text = "¤ Collect your reward"; //Spawn staff
                        break;
                    case WaterStaffQuestLine.GoBackToRanger: //6
                        questTitle.text = "Back To Ranger";
                        questLog.text = "¤ Let's show the Ranger our new staff";
                        break;
                    case WaterStaffQuestLine.EndQuest:
                        activeWaterStaffQuest = false;
                        activeBossQuest = true;
                        currentBossState = BossQuestLine.TalkToSlime;
                        break;
                }
            }

            if (activeBossQuest)
            {
                switch (currentBossState)
                {
                    case BossQuestLine.TalkToSlime:
                        questTitle.text = "Mimmi";
                        questLog.text = "¤ Talk to Mimmi";
                        break;
                    case BossQuestLine.FindBossArea:
                        questTitle.text = "Find Boss Area";
                        questLog.text = "¤ Follow Mimi";
                        break;
                    case BossQuestLine.DefeatBoss:
                        questTitle.text = "Defeat the Stone Creature!";
                        questLog.text = "0_0 He's big... 0_0";
                        break;
                    case BossQuestLine.ReturnToRanger:
                        questTitle.text = "Congratulations!";
                        questLog.text = "¤ Let's head back to the ranger ";
                        break;
                }
            }
        }

        void SetState(int part)
        {
            if (activeWaterStaffQuest)
            {
                if (part == 1)
                    currentWaterStaffState = WaterStaffQuestLine.FindingBearMan;
                else if (part == 2)
                    currentWaterStaffState = WaterStaffQuestLine.CollectingCrate;
                else if (part == 3)
                    currentWaterStaffState = WaterStaffQuestLine.FindingRiverByRangerArea;
                else if (part == 4)
                    currentWaterStaffState = WaterStaffQuestLine.SaveTheRiver;
                else if (part == 5)
                    currentWaterStaffState = WaterStaffQuestLine.GettingReward;
                else if (part == 6)
                    currentWaterStaffState = WaterStaffQuestLine.GoBackToRanger;
                else if (part == 7)
                    currentWaterStaffState = WaterStaffQuestLine.EndQuest;
            }

            if (activeBossQuest)
            {
                //TODO: when invoking event. Implement quest state
                if (part == 1)
                    currentBossState = BossQuestLine.TalkToSlime;
                else if (part == 2)
                    currentBossState = BossQuestLine.FindBossArea;
                else if (part == 3)
                    currentBossState = BossQuestLine.DefeatBoss;
                else if (part == 4)
                    currentBossState = BossQuestLine.ReturnToRanger;
            }
        }
    }
}