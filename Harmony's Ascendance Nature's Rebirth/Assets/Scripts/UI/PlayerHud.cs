using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text magicText;
    public TMP_Text expText;
    public TMP_Text levelText;

    private void Update()
    {
        healthText.text = "Health:" + GetComponent<PlayerStats>().health;
        magicText.text = "Magic: " + GetComponent<PlayerStats>().magic;
        expText.text = "Exp: " + GetComponent<PlayerStats>().exp; 
        levelText.text = "Level: " + GetComponent<PlayerStats>().level;
    }
}


