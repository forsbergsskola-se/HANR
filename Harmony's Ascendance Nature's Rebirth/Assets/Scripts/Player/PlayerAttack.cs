using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Enemy.BossEnemy;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PlayerAttack : MonoBehaviour
{
    public BoolVariable playerMoving;
    public Animator animator;
    public GameObjectVariable currentClickedEmeny;
    private NavMeshAgent agent;
    private Quaternion toRotation;
    private GameObject weaponEquipped;
    private bool attackStarted;
    private bool projectileAway;
    private GameObject enemyToAttack;
    private DefaultAttackPool daAttackPool;
    private float projectileSpeed = 10f;// Should come from weapon stats later
    private float attackDamage = 3f;// Should come from weapon stats later
    private float playerAttackRange = 15f; //Should come from player stats later on
    

    
    private void Awake()
    {
        currentClickedEmeny.ValueChanged.AddListener(trackEnemy);

    }

    private void OnDestroy()
    {
        currentClickedEmeny.ValueChanged.RemoveListener(trackEnemy);
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
            StopCoroutine(checkDistance());
        }
        
    }

    private IEnumerator checkDistance()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, enemyToAttack.transform.position);
        
        if (distance > playerAttackRange)
        {
            playerMoving.setValue(true);
            animator.SetBool("isDefaultAttack", false);
        }
        
        while (distance > playerAttackRange)
        {
            distance = Vector3.Distance(this.gameObject.transform.position, enemyToAttack.transform.position);
            yield return null; 
        }
        
        playerMoving.setValue(false);
        animator.SetBool("isDefaultAttack", true);
    }

    private void Start()
    {
        daAttackPool = this.gameObject.GetComponent<DefaultAttackPool>();
        weaponEquipped = gameObject.GetComponentInChildren<WeaponEquipped>().gameObject;
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
        Vector3 direction = (-projectile.transform.position + enemyToAttack.GetComponentInChildren<HitPoint>().transform.position).normalized;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        ProjectileStats ps = projectile.GetComponent<ProjectileStats>();
        rb.velocity = new Vector3(direction.x * projectileSpeed, direction.y * projectileSpeed, direction.z * projectileSpeed);
        ps.attackDamage = attackDamage;
    }
    
    private void FaceEnemy()
    {
        Vector3 direction = (enemyToAttack.transform.position - this.gameObject.transform.position).normalized;
        direction.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = toRotation;
    }

}
