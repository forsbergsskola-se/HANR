using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using CustomObjects;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public UnityEvent druidToRanger;
    public TMP_Text chating;
    private int dialougeCounter;

    [SerializeField] private GameObject PlayerUI;
    [SerializeField] private NavMeshAgent agent;
    private string[] conversation = new string[4];
    private bool inConversation;
    
    private void Start()
    {
        this.gameObject.SetActive(false);
        druidToRanger.AddListener(InitiateDialogue);
        FillArray();
    }

    private void OnDestroy()
    {
        druidToRanger.RemoveListener(InitiateDialogue);
    }

    private void InitiateDialogue()
    {
        Debug.Log("Event kicked"); // this shows up but nothing underneath is done.
        
        
        PlayerUI.SetActive(false);
        this.gameObject.SetActive(true);
        agent.isStopped = true;
        
        chating.text = conversation[0];
        dialougeCounter++;
        
        inConversation = true;
        
        keepConversing:
        if (inConversation && dialougeCounter < 4)
        {
            if (Input.GetKeyDown(KeyCode.Space) && dialougeCounter == 1)
            {
                chating.text = conversation[1];
                dialougeCounter++;
                goto keepConversing;
            }
            if (Input.GetKeyDown(KeyCode.Space) && dialougeCounter == 2)
            {
                chating.text = conversation[2];
                dialougeCounter++;
                goto keepConversing;
            }
            if (Input.GetKeyDown(KeyCode.Space) && dialougeCounter == 3)
            {
                chating.text = conversation[3];
                dialougeCounter++;
                inConversation = false;
            }   
        } 
        this.gameObject.SetActive(false);
        PlayerUI.SetActive(true);
        agent.isStopped = false;
    }
    

    private void FillArray()
    {
        conversation[0] = "I'm distraught, the water in these woods are vital for all life but has been curated by darkness and is slowly killing everything that is dependent on it.";
        conversation[1] = "text2";
        conversation[2] = "text3";
        conversation[3] = "text4";
    }
    
    
    /*
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
