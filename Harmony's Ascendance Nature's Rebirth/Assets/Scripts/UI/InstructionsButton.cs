using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsButton : MonoBehaviour
{
    public GameObject instructionsPanel;

    void Start()
    {
        instructionsPanel.SetActive(false);
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
    }
}
