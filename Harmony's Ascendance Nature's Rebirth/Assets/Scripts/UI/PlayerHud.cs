using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text magicText;
    public TMP_Text expText;
    public TMP_Text levelText;

    public float healthBarValue;
    public float magicBarValue;
    public float expBarValue;
    public int levelBarValue;
    public PlayerStats playerStats;

    public Slider healthSlider;
    public Slider magicSlider;
    public Slider expSlider;
    
    void UpdateStats()
    {
        healthBarValue = playerStats.health;
        magicBarValue = playerStats.magic;
        expBarValue = playerStats.exp;
        levelBarValue = playerStats.level;
    }

    void Update() // TODO
    {
        healthSlider.maxValue = 100f;
        healthSlider.value = playerStats.health; //Current value
        healthSlider.minValue = 0f;
        magicSlider.maxValue = 100f;
        magicSlider.value = playerStats.magic; //Current value
        magicSlider.minValue = 0f;
        expSlider.maxValue = 100f;
        expSlider.value = playerStats.exp; //Current value
        expSlider.minValue = 0f;
        
        healthText.text = "Health:" + GetComponent<PlayerStats>().health;
        magicText.text = "Magic: " + GetComponent<PlayerStats>().magic;
        expText.text = "Exp: " + GetComponent<PlayerStats>().exp; 
        levelText.text = "Lv: " + GetComponent<PlayerStats>().level;
        UpdateStats();
    }
}