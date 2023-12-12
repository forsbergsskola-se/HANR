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
    private int dialougeCounter = 0;

    private GameObject PlayerUI;
    [SerializeField] private NavMeshAgent agent;
    private string[] conversation = new string[5];
    private bool inConversation;

    public QuestUI questUI;

    
    private void Start()
    {
        this.gameObject.SetActive(false);
        druidToRanger.AddListener(InitiateDialogueRanger);
        druidToBearMan.AddListener(InitiateDialogueBearMan);
        PlayerUI = GameObject.FindWithTag("Canvas");
        //talkingFace = druidFace; //Face in first dialogue, in this case, ranger
        
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
        conversation[0] = "I'm distraught, the water in these woods are vital for all life but has been corrupted by darkness and is slowly killing everything that is dependent on it.";
        conversation[1] = "Oh hello! What do you mean? Who corrupted the water?";
        conversation[2] = "Dark forces has spread over these lands lately, it came from deep in the mountains... Those fire rocks are so evil, this forest used to be so beautiful!";
        conversation[3] = "I know some magic, maybe I can help?";
        conversation[4] = "There is a tale of a purifying spell crafted by the Bear Man. He keeps to himself and can be hard to find, but I've heard that he likes carving runes in to stone...";
    }
    
    private void FillArrayBearMan()
    {
        conversation[0] = "Rawr! Who goes there?";
        conversation[1] = "Don't be alarmed, I'm a friend! I'm searching for a spell to purify the river by the Rangers grounds";
        conversation[2] = "Oh, you're a friend of little Ranger? In that case I may be able to help you. It's been a long time since I used magic, other than to carve my masterpieces.";
        conversation[3] = "There should be some crates with potions by the pine trees, feel free to have a look!";
        conversation[4] = "Thank you ";
    }
    
    /*x
    private void InitiateDialogue()
    {
        PlayerUI.SetActive(false);
        this.gameObject.SetActive(true);
        dialougeCounter = 0;
        do
        {
            StartCoroutine(WaitForKeyPress());
        } while (dialougeCounter < 5);
    }
    
    private IEnumerator WaitForKeyPress()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        { 
            yield return null;
        }
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        if (dialougeCounter == 0)
        {
            chating.text = conversation[0];
            dialougeCounter++;
        }
        else if (dialougeCounter == 1)
        {
            chating.text = conversation[1];
            dialougeCounter++;
        }
        else if (dialougeCounter == 2)
        {
            chating.text = conversation[2];
            dialougeCounter++;
        }
        else if (dialougeCounter == 3)
        {
            chating.text = conversation[3];
        }*/
}
