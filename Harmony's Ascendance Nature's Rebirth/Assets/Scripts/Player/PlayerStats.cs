using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Mall/Create Mall")]
public class PlayerStats : ScriptableObject
{
    public float health = 100;
    public float magic = 50;
    public float exp = 0;
    public int level = 1;
    
}