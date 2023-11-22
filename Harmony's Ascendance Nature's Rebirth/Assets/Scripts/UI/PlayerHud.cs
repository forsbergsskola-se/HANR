using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public TMP_Text healthText; // Text for bars
    public TMP_Text magicText;
    public TMP_Text expText;
    public TMP_Text levelText;

    public PlayerStats playerStats;

    public Slider healthSlider;
    public Slider magicSlider;
    public Slider expSlider;
    
    private void Awake()
    {
        SetUpPlayerHUD();
    }

    private void SetUpPlayerHUD()
    {
        healthSlider.minValue = 0;
        healthSlider.maxValue = 100;
        magicSlider.minValue = 0;
        magicSlider.maxValue = 100;
        expSlider.minValue = 0;
        expSlider.maxValue = 100;
    }
    
    private void UpdatePlayerHealth()
    {
        healthSlider.value = playerStats.health; //Current value
        healthText.text = "Health:" + playerStats.health;
        // TODO FindObjectOfType<PlayerUser>().UpdatePlayerHUD.();
    }

    private void UpdatePlayerMagic()
    {
        magicSlider.value = playerStats.magic; //Current value
        magicText.text = "Magic: " + playerStats.magic;
    }

    private void UpdatePlayerExp()
    {
        expSlider.value = playerStats.exp; //Current value
        expText.text = "Exp: " + playerStats.exp;
        levelText.text = "Lv: " + playerStats.level;
    }
}