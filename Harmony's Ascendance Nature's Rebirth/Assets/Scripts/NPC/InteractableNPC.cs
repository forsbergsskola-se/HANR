using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playerClose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
        }
        
    }
    private void OnTriggerStay(Collider other) //TODO code runs twice?
    {
        if(playerClose && Input.GetKeyDown(KeyCode.Space)) //If player is close enough, press right mouse to trigger dialogue
        {
            dialogue.druidToRanger.Invoke();
        }
    }
}
