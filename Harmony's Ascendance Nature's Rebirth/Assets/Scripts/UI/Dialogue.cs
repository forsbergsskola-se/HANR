using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public UnityEvent druidToRanger;
    public TMP_Text chating;
    private int dialougeCounter;

    public GameObject PlayerUI;

    private bool isInDialogue;
    private bool keyPressed;

    private string[] conversation = new string[4];

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

    private void FillArray()
    {
        conversation[0] =
            "I'm distraught, the water in these woods are vital for all life but has been curated by darkness and is slowly killing everything that is dependent on it.";

        conversation[1] = "text2";
        conversation[2] = "text3";
        conversation[3] = "text4";

    }

    private void InitiateDialogue()
    {
        PlayerUI.SetActive(false);
        this.gameObject.SetActive(true);
        dialougeCounter = 0;
        
        StartCoroutine(WaitForKeyPress());
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
        if (dialougeCounter == 1)
        {
            chating.text = conversation[1];
            dialougeCounter++;
        }
        if (dialougeCounter == 2)
        {
            chating.text = conversation[2];
            dialougeCounter++;
        }
        if (dialougeCounter == 3)
        {
            chating.text = conversation[3];
        }
    }
}
