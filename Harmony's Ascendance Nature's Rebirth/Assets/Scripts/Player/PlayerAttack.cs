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
    public BoolVariable playerMoving;
    public BoolVariable playerAttacking;
    public Animator animator;
    public GameObjectVariable currentClickedEmeny;
    private NavMeshAgent agent;
    private Quaternion toRotation;
    private GameObject weaponEquipped;
    private GameObject enemyHead; // Don't know know to find this?
    private bool attackStarted;
    private bool projectileAway;
    private GameObject enemyToAttack;
    private DefaultAttackPool daAttackPool;
    private float projectileSpeed = 3f;// Should come from weapon stats later
    private float attackDamage = 3f;// Should come from weapon stats later
    private float playerAttackRange = 15f; //Should come from player stats later on
    

    
    private void Awake()
    {
        // playerAttacking.ValueChanged.AddListener(InitiateAttack);
        currentClickedEmeny.ValueChanged.AddListener(trackEnemy);
        //enemyInRange.ValueChanged.AddListener();

    }

    private void OnDestroy()
    {
        // playerAttacking.ValueChanged.RemoveListener(InitiateAttack);
        currentClickedEmeny.ValueChanged.RemoveListener(trackEnemy);
        //enemyInRange.ValueChanged.RemoveListener();
    }

    private void trackEnemy(GameObject enemy)
    {
        if (enemy)
        {
            enemyToAttack = enemy;
            StartCoroutine(checkDistance());
        }
        else
        {
            animator.SetBool("isDefaultAttack", false);
        }
        
    }

    private IEnumerator checkDistance()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, enemyToAttack.transform.position);
        if (distance > playerAttackRange)
        {
            playerMoving.setValue(true);
        }

        while (true)
        {
            if (distance <= playerAttackRange)
            {
                Debug.Log("Here");
                animator.SetBool("isDefaultAttack", true);
                playerMoving.setValue(false);
                yield break;
            }
        }
    }

    private void Start()
    {
        daAttackPool = this.gameObject.GetComponent<DefaultAttackPool>();
        weaponEquipped = gameObject.GetComponentInChildren<WeaponEquipped>().gameObject;
        //enemyHead = gameObject.GetComponent<EnemyHead>().gameObject;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void DefaultAttack()
    {
        FaceEnemy();
        GameObject projectileInstance = daAttackPool.GetPooledEffects();
        if (projectileInstance != null)
        {
            projectileInstance.transform.position = weaponEquipped.transform.position;
            projectileInstance.transform.rotation = weaponEquipped.transform.rotation;
            
            ShootProjectile(projectileInstance);
        }
    }
    
    private void ShootProjectile(GameObject projectile)
    {
        Vector3 direction = (-projectile.transform.position + enemyToAttack.transform.position);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        ProjectileStats ps = projectile.GetComponent<ProjectileStats>();
        rb.velocity = new Vector3(direction.x * projectileSpeed, direction.y * projectileSpeed, direction.z * projectileSpeed);
        ps.attackDamage = attackDamage;
    }
    
    /*
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
    }*/

    private void FaceEnemy()
    {
        Vector3 direction = (enemyToAttack.transform.position - this.gameObject.transform.position).normalized;
        direction.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime*20);
    }

}
