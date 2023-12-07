using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "SO/Skills", order = 0)]
public class Skills : ScriptableObject
{
    public string name;
    public float mana;
    public float range;
    public float damage;
    public float cooldown;
    public bool pointClick;
    public Sprite icon;
    public GameObject skillObject;
}
