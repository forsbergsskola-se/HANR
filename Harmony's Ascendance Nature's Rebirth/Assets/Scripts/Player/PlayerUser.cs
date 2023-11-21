using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUser : MonoBehaviour
{
    public UnityEvent UpdatePlayerHUD = new UnityEvent();
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
    private void OnCollisionEnter(Collision other)
    { 
        playerStats.health -= 30;
        UpdatePlayerHUD.Invoke();
    }
}