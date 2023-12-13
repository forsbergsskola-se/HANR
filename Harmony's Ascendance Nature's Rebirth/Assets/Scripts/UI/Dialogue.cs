using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using CustomObjects;
using TMPro;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public UnityEvent druidToRanger;
    public UnityEvent druidToBearMan;
    public TMP_Text chating;
    public int dialougeCounter = 0;

    private GameObject PlayerUI;
    [SerializeField] private NavMeshAgent agent;
    public string[] conversation = new string[5];
    private bool inConversation;

    public QuestUI questUI;

    
    private void Start()
    {
        this.gameObject.SetActive(false);
        druidToRanger.AddListener(InitiateDialogueRanger);
        druidToBearMan.AddListener(InitiateDialogueBearMan);
        PlayerUI = GameObject.FindWithTag("Canvas");
    }

    private void Update()
    {
        if (inConversation)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                questUI.gameObject.SetActive(false);
                if (dialougeCounter > conversation.Length-1)
                {
                    inConversation = false;
                    dialougeCounter = 0;
                    this.gameObject.SetActive(false);
                    PlayerUI.SetActive(true);
                    questUI.gameObject.SetActive(true);
                }
                else
                {
                    chating.text = conversation[dialougeCounter];
                    dialougeCounter += 1;
                }
            }
        }
    }

    private void OnDestroy()
    {
        druidToRanger.RemoveListener(InitiateDialogueRanger);
        druidToBearMan.RemoveListener(InitiateDialogueBearMan);
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
            dialougeCounter += 1;
            inConversation = true;
            if(questUI.currentState == QuestUI.QuestLine.TalkingToRanger) //To not retrigger same quest-objective
                questUI.questProgression.Invoke(1); //State goes to next (FindingBearMan)
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
            dialougeCounter += 1;
            inConversation = true;
        }
        
    }

    private void FillArrayRanger()
    {
        if (questUI.currentState == QuestUI.QuestLine.TalkingToRanger)
        {
            conversation[0] = "I'm distraught, the water in these woods are vital for all life but has been corrupted by darkness and is slowly killing everything that is dependent on it.";
            conversation[1] = "Oh hello! What do you mean? Who corrupted the water?";
            conversation[2] = "Dark forces has spread over these lands lately, it came from deep in the mountains... Those fire rocks are so evil, this forest used to be so beautiful!";
            conversation[3] = "I know some magic, maybe I can help?";
            conversation[4] = "There is a tale of a purifying spell crafted by the Bear Man. He keeps to himself and can be hard to find, but I've heard that he likes carving runes in to stone...";
        }
        else if (questUI.currentState != QuestUI.QuestLine.TalkingToRanger) //If Druid retriggers the conversation again
        {
            conversation[0] = "Go find the BearMan please!";
            dialougeCounter = 4; //To cut the dialogue short
        }
        else if (questUI.currentState == QuestUI.QuestLine.EndQuest)
        {
            conversation[0] = "You have a staff now!";
            conversation[1] = "Now you can fight the monsters!";
            dialougeCounter = 4; //To cut the dialogue short
        }
    }

    private void FillArrayBearMan()
    {
        if (questUI.currentState == QuestUI.QuestLine.FindingBearMan)
        {
            conversation[0] = "Rawr! Who goes there?";
            conversation[1] = "Don't be alarmed, I'm a friend! I'm searching for a spell to purify the river by the Rangers grounds";
            conversation[2] = "Oh, you're a friend of little Ranger? In that case I may be able to help you. It's been a long time since I used magic, other than to carve my masterpieces.";
            conversation[3] = "There should be some crates with spell books and potions by the pine trees, feel free to have a look!";
            conversation[4] = "Thank you";
        }
        else if (questUI.currentState != QuestUI.QuestLine.FindingBearMan)//If Druid goes to BearMan to soon
        {
            conversation[0] = "Growl! GET AWAY FROM ME!";
            dialougeCounter = 4; //To cut the dialogue short
        }
        else if (questUI.currentState == QuestUI.QuestLine.TalkingToRanger)
        {
            conversation[0] = "You have the Water Staff!";
            conversation[1] = "Now go save the forest!";
            dialougeCounter = 4; //To cut the dialogue short
        }
    }
}
