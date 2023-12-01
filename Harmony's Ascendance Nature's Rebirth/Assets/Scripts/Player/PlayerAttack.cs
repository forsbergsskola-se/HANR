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
    private bool attackStarted;
    private bool projectileAway;

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
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void InitiateAttack(bool playerAttacking)
    {
        if (playerAttacking)
        {
            attackStarted = true;
            
            

            isDefaultAttack.setValue(true);
        }
    }

    private void DefaultAttack(bool isDefaultAttack)
    {
        if (isDefaultAttack && attackStarted)
        {
            FaceEnemy();
            enemyToAttack = targetPoint.GetValue();
            GameObject projectileInstance = daAttackPool.GetPooledEffects();
            if (projectileInstance != null)
            {
                projectileInstance.transform.position = weaponEquipped.transform.position;
                projectileInstance.transform.rotation = weaponEquipped.transform.rotation;
                
                projectileAway = true;
                ShootProjectile(projectileInstance, enemyToAttack);
            }
            StartCoroutine(DefaultCooldown());
            attackStarted = false;
            projectileAway = false;
        }
    }
    
    [ContextMenu("Test Shoot")] 
    private void ShootProjectile(GameObject projectile, Vector3 enemyPos)
    {
        Vector3 direction = (projectile.transform.position - enemyPos);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        float height = Mathf.Abs(direction.y);
        float Vx = direction.x * Mathf.Sqrt(-Physics.gravity.y / (2 * height));
        float Vz = direction.z * Mathf.Sqrt(-Physics.gravity.y / (2 * height));
        rb.velocity = new Vector3(Vx*2f, 0, Vz*2f);
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
        Debug.Log("Should rotate towards enemy");
    }

    private IEnumerator DefaultCooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}
