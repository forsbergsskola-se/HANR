using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using CustomObjects;
using Player;
using TMPro;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public UnityEvent druidToRanger;
    public UnityEvent druidToBearMan;
    public UnityEvent druidToSlime;
    public TMP_Text chating;
    public int dialougeCounter = 0;

    [SerializeField] private Image currentlySpeaking; //For dialogue images
    public Sprite faceDruid;
    public Sprite faceRanger;
    public Sprite faceBearMan;
    
    private GameObject PlayerUI;
    [SerializeField] private NavMeshAgent agent;
    public string[] conversation = new string[5];
    private bool inConversation;
    
    public Quest quest;
    public CameraScript cameraScript;

    
    private void Start()
    {
        this.gameObject.SetActive(false);
        druidToRanger.AddListener(InitiateDialogueRanger);
        druidToBearMan.AddListener(InitiateDialogueBearMan);
        druidToSlime.AddListener(InitiateDialogueSlime);
        PlayerUI = GameObject.FindWithTag("Canvas");
    }
    
    private void OnDestroy()
    {
        druidToRanger.RemoveListener(InitiateDialogueRanger);
        druidToBearMan.RemoveListener(InitiateDialogueBearMan);
        druidToSlime.RemoveListener(InitiateDialogueSlime);
    }

    private void Update()
    {
        if (inConversation)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                quest.gameObject.SetActive(false);
                
                if (dialougeCounter > conversation.Length-1) //End conversation
                {
                    inConversation = false;
                    dialougeCounter = 0;
                    this.gameObject.SetActive(false);
                    PlayerUI.SetActive(true);
                    quest.gameObject.SetActive(true);
                    cameraScript.UnLock();

                    switch (quest.currentWaterStaffState)
                    {
                        case Quest.WaterStaffQuestLine.TalkingToRanger:
                            quest.questProgression.Invoke(1); //State goes to next (FindingBearMan)
                            break;
                        case Quest.WaterStaffQuestLine.FindingBearMan:
                            quest.questProgression.Invoke(2); //State goes to next (CollectingCrate)
                            break;
                        case Quest.WaterStaffQuestLine.GoBackToRanger: 
                            quest.questProgression.Invoke(7); //End quest-line, thus start next one
                            break;
                    }
                    
                    currentlySpeaking.sprite = null;
                }
                else //Dialogue continues
                {
                    chating.text = conversation[dialougeCounter];
                    
                    //For dialogue face images
                    if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.TalkingToRanger) // When talking to ranger first time
                    {
                        if (chating.text == conversation[1] || chating.text == conversation[3])
                        {
                            currentlySpeaking.sprite = faceDruid;
                        }
                        else if (chating.text == conversation[2] ||
                                 chating.text == conversation[4])
                        {
                            currentlySpeaking.sprite = faceRanger;
                        }
                    }
                    else if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.GoBackToRanger)
                    {
                        currentlySpeaking.sprite = faceRanger;
                    }

                    if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.FindingBearMan)
                    {
                        if (chating.text == conversation[1] || chating.text == conversation[3])
                        {
                            currentlySpeaking.sprite = faceDruid;
                        }
                        else if (chating.text == conversation[2] ||
                                 chating.text == conversation[4])
                        {
                            currentlySpeaking.sprite = faceBearMan;
                        }
                    }

                    if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.GoBackToRanger)
                    {
                        if (chating.text == conversation[1] || chating.text == conversation[3])
                        {
                            currentlySpeaking.sprite = faceDruid;
                        }
                        else if (chating.text == conversation[2] ||
                                 chating.text == conversation[4])
                        {
                            currentlySpeaking.sprite = faceRanger;
                        }
                    }
                    dialougeCounter += 1;
                }
            }
        }
    }
    
    private void InitiateDialogueRanger()
    {
        if (!inConversation && dialougeCounter == 0)
        {
            FillArrayRanger();
            PlayerUI.SetActive(false);
            this.gameObject.SetActive(true);
            agent.isStopped = true;
            chating.text = conversation[0];
            currentlySpeaking.sprite = faceRanger;
            dialougeCounter += 1;
            inConversation = true;
        }
        
    }
    
    private void InitiateDialogueBearMan()
    {
        if (!inConversation && dialougeCounter  == 0)
        {
            FillArrayBearMan();
            PlayerUI.SetActive(false);
            this.gameObject.SetActive(true);
            agent.isStopped = true;
            chating.text = conversation[0];
            currentlySpeaking.sprite = faceBearMan;
            dialougeCounter += 1;
            inConversation = true;
        }
        
    }
    private void InitiateDialogueSlime()
    {
        if (!inConversation && dialougeCounter  == 0)
        {
            FillArraySlime();
            PlayerUI.SetActive(false);
            this.gameObject.SetActive(true);
            agent.isStopped = true;
            chating.text = conversation[0];
            currentlySpeaking.sprite = faceBearMan;
            dialougeCounter += 1;
            inConversation = true;
        }
        
    }

    private void FillArrayRanger() //Dialogue lines
    {
        if (quest.activeWaterStaffQuest)
        {
            if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.TalkingToRanger)
            {
                conversation[0] = "I'm distraught, the water in these woods are vital for all life but has been corrupted by darkness and is slowly killing everything that is dependent on it.";
                conversation[1] = "Oh hello! What do you mean? Who corrupted the water?";
                conversation[2] = "Dark forces has spread over these lands lately, it came from deep in the mountains... Those fire rocks are so evil, this forest used to be so beautiful!";
                conversation[3] = "I know some magic, maybe I can help?";
                conversation[4] = "There is a tale of a purifying spell crafted by the Bear Man. He keeps to himself and can be hard to find, but I've heard that he likes carving runes in to stone...";
            }

            else if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.GoBackToRanger)
            {
                conversation[0] = "Thank you so much for your help!";
                conversation[1] = "Don't mention it! Your home looks so beautiful now that the river is clean.";
                conversation[2] = "It used to always look at this, but after the this stone creature woke up inside the mountain the forest turned dark.";
                conversation[3] = "What are those stone creatures?";
                conversation[4] = "Follow my friend Slimy, he'll show you where it resides.";
            }
            else if (quest.currentWaterStaffState != Quest.WaterStaffQuestLine.TalkingToRanger) //If player tries to retrigger the conversation again
            {
                conversation[0] = "Go find the BearMan please!";
                dialougeCounter = 4; //To cut the dialogue short
            }
        }
    }

    private void FillArrayBearMan() //Dialogue lines
    {
        if (quest.activeWaterStaffQuest)
        {
            if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.FindingBearMan)
            {
                conversation[0] = "Rawr! Who goes there?";
                conversation[1] =
                    "Don't be alarmed, I'm a friend! I'm searching for a spell to purify the river by the Rangers grounds";
                conversation[2] =
                    "Oh, you're a friend of little Ranger? In that case I may be able to help you. It's been a long time since I used magic, other than to carve my masterpieces.";
                conversation[3] =
                    "There should be some crates with spell books and potions by the pine trees, feel free to have a look!";
                conversation[4] = "Thank you";
            }
            else if (quest.currentWaterStaffState !=
                     Quest.WaterStaffQuestLine.FindingBearMan) //If Druid goes to BearMan to soon
            {
                conversation[0] = "Growl! GET AWAY FROM ME!";
                dialougeCounter = 4; //To cut the dialogue short
            }
            else if (quest.currentWaterStaffState == Quest.WaterStaffQuestLine.GoBackToRanger)
            {
                conversation[0] = "You have the Water Staff Now go save the forest!";
                dialougeCounter = 4; //To cut the dialogue short
            }
        }
    }

    private void FillArraySlime()
    {
        if (!quest.activeBossQuest)
        {
            conversation[0] = "Hello friend!";
            dialougeCounter = 4; //To cut the dialogue short
        } 
        else
        {
            conversation[0] = "Our savior! Let me guide you to the stone creature.";
            dialougeCounter = 4; //To cut the dialogue short
        }
    }
}
