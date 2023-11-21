using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Mall/Create Mall")]
public class PlayerStats : ScriptableObject
{
    public float health;
    public float magic;
    public float exp;
    public int level;
}