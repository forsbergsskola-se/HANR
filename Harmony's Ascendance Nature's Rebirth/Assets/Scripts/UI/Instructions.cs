using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Instructions : MonoBehaviour
{

    public UnityEvent<string> buttonInput;
    public TMP_Text buttonInstructions;


    private void Start()
    {
        this.gameObject.SetActive(false);
        buttonInput.AddListener(SetShowButton);
    }

    private void OnDestroy()
    {
        buttonInput.RemoveListener(SetShowButton);
    }

    public void SetShowButton(string button)
    {
        switch (button)
        {
            case "Teleport":
                buttonInstructions.text = "Press [T] to teleport";
                break;
            case "Item":
                buttonInstructions.text = "Press [G] to pick up";
                break;
            case "Interact":
                buttonInstructions.text = "Press [G] to interact";
                break;
            case "River":
                buttonInstructions.text = "Use the book!";
                break;
            case null:
                buttonInstructions.text = null;
                break;
        }
    }
}