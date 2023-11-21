using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUser : MonoBehaviour
{
    public PlayerStats playerStats;

    void Start()
    {
        playerStats.health = 100;
        playerStats.magic = 100;
        playerStats.exp = 0;
        playerStats.level = 1;
    }
}