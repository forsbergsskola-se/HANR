using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    //public BoolVariable playerMoving;
    public BoolVariable playerAttacking;
    public BoolVariable isDefaultAttack;
    public TargetPoint targetPoint;
    public Animator animator;
    
    private NavMeshAgent agent;
    private Quaternion toRotation;
    private bool isAttacking;
    private Vector3 enemyToAttack;
    private DefaultAttackPool daAttackPool;
    
    
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

    private void Start()
    {
        daAttackPool = this.gameObject.GetComponent<DefaultAttackPool>();
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
        //animator.ResetTrigger("isDefaultAttack");
        if (isDefaultAttack && !isAttacking)
        {
            FaceEnemy();
            animator.SetTrigger("isDefaultAttack");
            
            GameObject effectInstance = daAttackPool.GetPooledEffects();
            if (effectInstance != null)
            {
                enemyToAttack = targetPoint.GetValue();
                effectInstance.transform.position = enemyToAttack += new Vector3(0,0.3f,0);
            }
            
            playerAttacking.setValue(false);
        }
    }

    private void FaceEnemy()
    {
        Debug.Log("Should rotate towards enemy");
    }

}
