using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Skills", menuName = "SO/Skills", order = 0)]
public class Skills : ScriptableObject
{
    public string name;
    public float mana;
    public float range;
    public float damage;
    public int cooldown;
    public bool pointClick;
    public Sprite icon;
    public GameObject skillObject;
    public int currentCooldown;
    public UnityEvent<int> valueChanged;
    
    public void setCurrentCooldown(int cd)
    {
        currentCooldown = cd;
        valueChanged.Invoke(currentCooldown);
    }
    
    public int getCurrentCooldown()
    {
        return currentCooldown;
    }
}
