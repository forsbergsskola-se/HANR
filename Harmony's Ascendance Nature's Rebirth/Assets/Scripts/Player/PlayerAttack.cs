using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //public BoolVariable playerMoving;
    public BoolVariable playerAttacking;
    public TargetPoint targetPoint;

    private Vector3 enemyPosition;
    
    
    private void Awake()
    {
        playerAttacking.ValueChanged.AddListener(NormalAttack);
    }

    private void OnDestroy()
    {
        playerAttacking.ValueChanged.RemoveListener(NormalAttack);
    }

    private void NormalAttack(bool playerAttacking)
    {
        if (playerAttacking)
        {
            enemyPosition = targetPoint.GetValue();
            
            Debug.Log("Attack");
        }
    }


}
