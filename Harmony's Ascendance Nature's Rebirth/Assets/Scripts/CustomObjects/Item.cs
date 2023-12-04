using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemClass;
    public string itemID;
    public Sprite itemIcon;
    public FloatVariable itemStat;
    public UnityEngine.Events.UnityEvent consumable;
    
}
