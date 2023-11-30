using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //public BoolVariable playerMoving;
    public BoolVariable playerAttacking;
    public BoolVariable isDefaultAttack;
    public TargetPoint targetPoint;
    
    private Animator animator;
    private bool isAttacking;
    private Vector3 enemyPosition;
    
    
    private void Awake()
    {
        playerAttacking.ValueChanged.AddListener(InitiateAttack);
        isDefaultAttack.ValueChanged.AddListener(DefaultAttack);
    }

    private void OnDestroy()
    {
        playerAttacking.ValueChanged.RemoveListener(InitiateAttack);
        isDefaultAttack.ValueChanged.RemoveListener(DefaultAttack);
    }

    private void InitiateAttack(bool playerAttacking)
    {
        if (playerAttacking)
        {
            // run checks on what weapon currently equipped
            // are any spells active?
            // Start corresponding attack;
            
            // face target (method) 
            // animate attack
            // get effect from pool
            // on hit, attack decreases mana and deals damage to enemy
            // Start a cooldown
            // playerAttacking = false
            
            
            isDefaultAttack.setValue(true);
        }
    }
    
    private void DefaultAttack(bool isDefaultAttack)
    {
        if (isDefaultAttack && !isAttacking)
        {
            Debug.Log("Spell cast");
            
            playerAttacking.setValue(false);
        }
    }


}
