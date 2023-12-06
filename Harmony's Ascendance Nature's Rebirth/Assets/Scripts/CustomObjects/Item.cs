using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemClass;
    public string itemID;
    public Sprite itemIcon;
    public float itemStat;
    public Skills skill1;
    public Skills skill2;
    public Skills ultiSkill;
}
