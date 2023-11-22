using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUser : MonoBehaviour
{
    public PlayerStats playerStats;
    void Update() //TODO : create a method, only called when stats changes, use unity-event
    {
        if (playerStats.health >= 100)
            playerStats.health = 100;
        else if (playerStats.health <= 0)
        {
            playerStats.health = 0;
        }
    }

    public void OnCollisionEnter(Collision other) // Testing purposes
    {
        playerStats.setValueExp(70);
        playerStats.setValueHealth(20);
        playerStats.setValueMagic(30);
    }
}