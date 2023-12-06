using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CustomObjects;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud2 : MonoBehaviour
{
    public TMP_Text healthText; // Text for bars
    public TMP_Text magicText;
    public TMP_Text levelText;
    
    public Slider healthSlider;
    public Slider magicSlider;
    public Slider expSlider;

    public FloatVariable health;
    public FloatVariable magic;
    public FloatVariable exp;
    public IntVariable level;

    public PlayerStat playerStat;
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
        health.ValueChanged.AddListener(updateHealth);
        magic.ValueChanged.AddListener(updateMagic);
        exp.ValueChanged.AddListener(updateExp);
        level.ValueChanged.AddListener(updateLevel);
    }

    private void OnDestroy()
    {
        health.ValueChanged.RemoveListener(updateHealth);
        magic.ValueChanged.RemoveListener(updateMagic);
        exp.ValueChanged.RemoveListener(updateExp);
        level.ValueChanged.RemoveListener(updateLevel);
    }

    private void updateHealth(float value)
    {
        healthText.text = value.ToString();
        healthSlider.value = value;
    }
    
    private void updateMagic(float value)
    {
        magicText.text = value.ToString();
        magicSlider.value = value;
    }
    
    private void updateExp(float value)
    {
        expSlider.value = value;
    }
    
    private void updateLevel(int value)
    {
        levelText.text = value.ToString();
        healthSlider.maxValue = playerStat.maxHealth; //TODO work in progress, goal: have sliders adapted to the changed stats when leveling up
        magicSlider.maxValue = playerStat.maxMagic;
        expSlider.maxValue = playerStat.maxExp;
    }
}