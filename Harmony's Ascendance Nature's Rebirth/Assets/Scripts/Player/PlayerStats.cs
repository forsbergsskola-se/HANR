using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Stats", menuName = "Mall/Create Mall")]
public class PlayerStats : ScriptableObject
{
    public UnityEvent UpdatePlayerHUD = new UnityEvent();
    
    public float health;
    public float magic;
    public float exp;
    public int level;

    public void setValueHealth(float newValue)
    {
        health = newValue;
        UpdatePlayerHUD.Invoke();
    }
}