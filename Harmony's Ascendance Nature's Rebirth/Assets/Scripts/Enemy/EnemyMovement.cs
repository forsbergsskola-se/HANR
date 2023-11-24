using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 orginalEnemyPosition;
    private Quaternion orginalEnemyrotation;
    [SerializeField] private NavMeshAgent agent;
    public BoolVariable playerInEnemyRange;
    public BoolVariable playerInAttackRange;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float turnRate;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        orginalEnemyPosition = this.gameObject.transform.position;
        orginalEnemyrotation = this.transform.rotation;
    }

    private void Awake()
    {
        playerInEnemyRange.ValueChanged.AddListener(startMovement);
        playerInAttackRange.ValueChanged.AddListener(attack);
    }

    private void OnDestroy()
    {
        playerInEnemyRange.ValueChanged.RemoveListener(startMovement);
        playerInAttackRange.ValueChanged.RemoveListener(attack);
    }
    
    private void attack(bool value){
       animator.SetBool("isInAttackRange", value);
    }

    private void FixedUpdate()
    {
        if (agent.velocity.magnitude > walkSpeed/2)
        {
            animator.SetBool("isMoving",true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        RotateToClick();
    }

    private void startMovement(bool playerInRange)
    {
        if (playerInRange)
        {
            agent.speed = walkSpeed;
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = orginalEnemyPosition;
        }
    }
    
    void RotateToClick()
    {
        if (agent.velocity != Vector3.zero && agent.hasPath)
        {
            Vector3 direction = agent.velocity.normalized;
            direction.y = 0;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime*turnRate);
        }

        if (agent.velocity == Vector3.zero && !playerInEnemyRange.getValue())
        {
            this.transform.rotation = orginalEnemyrotation;
        }
    }
    
}
