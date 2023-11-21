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

    
    void Start()
    {
        healthSlider.maxValue = 100;
        healthSlider.value = playerStats.health;
        healthSlider.minValue = 0;
        magicSlider.maxValue = 100;
        magicSlider.value = playerStats.magic;
        magicSlider.minValue = 0;
        expSlider.maxValue = 100;
        expSlider.value = playerStats.exp;
        expSlider.minValue = 0;
    }

    void UpdateStats()
    {
        healthBarValue = playerStats.health;
        magicBarValue = playerStats.magic;
        expBarValue = playerStats.exp;
        levelBarValue = playerStats.level;
    }
    
    
    void Update()
    {
        healthText.text = "Health:" + GetComponent<PlayerStats>().health;
        magicText.text = "Magic: " + GetComponent<PlayerStats>().magic;
        expText.text = "Exp: " + GetComponent<PlayerStats>().exp; 
        levelText.text = "Lv: " + GetComponent<PlayerStats>().level;
        UpdateStats();
    }
}