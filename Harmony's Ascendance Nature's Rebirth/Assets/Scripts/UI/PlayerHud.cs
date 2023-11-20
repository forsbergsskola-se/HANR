using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text magicText;

    private void Update()
    {
        healthText.text = "Health:" + GetComponent<PlayerStats>().health;
        magicText.text = "Magic: " + GetComponent<PlayerStats>().magic;
    }
}


