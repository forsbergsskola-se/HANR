using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGiveDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    
    public void OnCollisionEnter(Collision other)
    {
        playerStats.health -= 30;
    }
}
