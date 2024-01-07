using System; 
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Enemy.BossEnemy;
using Player;
using Player.SkillStats;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    public FloatVariable playerMana;
    public BoolVariable playerMoving;
    public Animator animator;
    public GameObjectVariable currentClickedEnemy;
    private NavMeshAgent agent;
    private Quaternion toRotation;
    private GameObject weaponEquipped;
    private bool attackStarted;
    private bool projectileAway;
    private GameObject enemyToAttack;
    private DefaultAttackPool daAttackPool;
    private UsableItems usableItems;
    private CombatStat combatStat;
    
    private void Awake()
    {
        
        usableItems = this.gameObject.GetComponent<UsableItems>();
        currentClickedEnemy.ValueChanged.AddListener(trackEnemy);
        usableItems.fireStaffEquipped.AddListener(setCombatStats);
        usableItems.waterStaffEquipped.AddListener(setCombatStats);
        usableItems.startStaffEquipped.AddListener(setCombatStats);

    }

    private void OnDestroy()
    {
        currentClickedEnemy.ValueChanged.RemoveListener(trackEnemy);
        usableItems.fireStaffEquipped.RemoveListener(setCombatStats);
        usableItems.waterStaffEquipped.RemoveListener(setCombatStats);
        usableItems.startStaffEquipped.RemoveListener(setCombatStats);
    }

    private void setCombatStats(Item item)
    {
        combatStat = item.normalAttack;
        
    }

    private void Start()
    {
        daAttackPool = this.gameObject.GetComponent<DefaultAttackPool>();
        weaponEquipped = gameObject.GetComponentInChildren<WeaponEquipped>().gameObject;
        animator = gameObject.GetComponentInChildren<Animator>();
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
            enemyToAttack = null;
            animator.SetBool("isDefaultAttack", false);
            StopCoroutine(checkDistance());
        }
        
    }

    private IEnumerator checkDistance()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, enemyToAttack.transform.position);
        
        if (distance > combatStat.range)
        {
            playerMoving.setValue(true);
            animator.SetBool("isDefaultAttack", false);
        }
        
        while (distance > combatStat.range)
        {
            distance = Vector3.Distance(this.gameObject.transform.position, enemyToAttack.transform.position);
            yield return null; 
        }
        
        playerMoving.setValue(false);
        animator.SetBool("isDefaultAttack", true);
        
    }
    
    public void DefaultAttack()
    {
        if (enemyToAttack != null)
        {
            FaceEnemy();
            GameObject projectileInstance = daAttackPool.GetPooledEffects();
            if (projectileInstance != null)
            {
                projectileInstance.transform.position = weaponEquipped.transform.position;
                projectileInstance.transform.rotation = weaponEquipped.transform.rotation;
                MeshRenderer mr = projectileInstance.GetComponent<MeshRenderer>();
                mr.material = combatStat.material;
            
                ShootProjectile(projectileInstance);
                
                float newMana = playerMana.getValue() - 5;
                playerMana.setValue(newMana);
            }
        }
        else
        {
            currentClickedEnemy.setValue(null);
        }
    }
        
    private void ShootProjectile(GameObject projectile)
    {
        SFX.SoundManager.PlaySound("Default Attack");
        Vector3 direction = (-projectile.transform.position + enemyToAttack.GetComponentInChildren<HitPoint>().transform.position).normalized;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        ProjectileStats ps = projectile.GetComponent<ProjectileStats>();
        rb.velocity = new Vector3(direction.x * combatStat.projectileSpeed, 
            direction.y * combatStat.projectileSpeed, direction.z * combatStat.projectileSpeed);
        ps.cs = combatStat;
    }
    
    private void FaceEnemy()
    {
        Vector3 direction = (enemyToAttack.transform.position - this.gameObject.transform.position).normalized;
        direction.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = toRotation;
    }

}
