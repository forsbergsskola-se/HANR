using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space)) //If player is close enough, press right mouse to trigger dialogue
        { 
            Debug.Log("Hello");
            dialogue.druidToRanger.Invoke();
        }
    }
}
