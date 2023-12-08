using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using TMPro;
using UnityEngine;

public class InteractableNPCRanger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playerClose;

    private void Update()
    {
        if (playerClose)
        {
            dialogue.druidToRanger.Invoke();
            playerClose = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
            Debug.Log("Player close");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
            Debug.Log("Walk away");
        }
    }
}
