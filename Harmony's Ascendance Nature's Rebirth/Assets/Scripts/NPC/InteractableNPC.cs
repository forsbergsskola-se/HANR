using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public Dialogue dialogue;
    public TMP_Text dialogueBubble;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Mouse0) == this.gameObject) //If player is close enough, press right mouse to trigger dialogue
        {
            dialogue.druidToRanger.Invoke();
        }
    }
}
