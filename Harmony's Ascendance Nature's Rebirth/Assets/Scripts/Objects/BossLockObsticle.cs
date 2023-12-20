using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;

public class BossLockObsticle : MonoBehaviour
{
    public FloatVariable playerHealth;
    private bool playerNear;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (playerNear)
        {
            float currentHealth = playerHealth.getValue();
            currentHealth -= 3 * Time.deltaTime;
            playerHealth.setValue(currentHealth);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}
