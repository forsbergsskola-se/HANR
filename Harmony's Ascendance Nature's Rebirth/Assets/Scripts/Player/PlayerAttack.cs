using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PlayerAttack : MonoBehaviour
{
    public BoolVariable enemyInRange;
    public BoolVariable playerAttacking;
    public BoolVariable isDefaultAttack;
    public TargetPoint targetPoint;
    public Animator animator;
    
    private NavMeshAgent agent;
    private Quaternion toRotation;
    
    private GameObject weaponEquipped;
    private GameObject enemyHead;
    
    private Vector3 enemyToAttack;
    private DefaultAttackPool daAttackPool;
    
    
    private void Awake()
    {
        playerAttacking.ValueChanged.AddListener(InitiateAttack);
        isDefaultAttack.ValueChanged.AddListener(DefaultAttack);
        //enemyInRange.ValueChanged.AddListener();
        
    }

    private void OnDestroy()
    {
        playerAttacking.ValueChanged.RemoveListener(InitiateAttack);
        isDefaultAttack.ValueChanged.RemoveListener(DefaultAttack);
        //enemyInRange.ValueChanged.RemoveListener();
    }

    private void Start()
    {
        daAttackPool = this.gameObject.GetComponent<DefaultAttackPool>();
        weaponEquipped = gameObject.GetComponent<WeaponEquipped>().gameObject;
        enemyHead = gameObject.GetComponent<EnemyHead>().gameObject;
    }

    private void InitiateAttack(bool playerAttacking)
    {
        if (playerAttacking)
        {
            // run checks on what weapon currently equipped
            // are any spells active?
            // Start corresponding attack;
            
            // Default Attack uses the ClickCheck and identifies the enemy clicked on.
            // face target (method) TODO. I'm not sure how to achieve this.
            // animate attack (Activates with trigger)
            // get effect from pool (This pool, like click effect, is in the player)
            // on hit, attack decreases mana and deals damage to enemy. TODO: Awaiting UI updates.
            // Start a cooldown (has a rudimentary cooldown)
            // playerAttacking = false
            
            isDefaultAttack.setValue(true);
        }
    }
    
    private void DefaultAttack(bool isDefaultAttack)
    {
        if (isDefaultAttack)
        {
            FaceEnemy();
            animator.SetTrigger("isDefaultAttack");
            this.isDefaultAttack.setValue(false);
            
            GameObject effectInstance = daAttackPool.GetPooledEffects();
            if (effectInstance != null)
            {
                enemyToAttack = targetPoint.GetValue();
                effectInstance.transform.position = enemyToAttack;
            }

            StartCoroutine(DefaultCooldown());
        }
        playerAttacking.setValue(false);
    }

    private void FaceEnemy()
    {
        Debug.Log("Should rotate towards enemy");
    }

    private IEnumerator DefaultCooldown()
    {
        yield return new WaitForSeconds(4f);
    }

}
