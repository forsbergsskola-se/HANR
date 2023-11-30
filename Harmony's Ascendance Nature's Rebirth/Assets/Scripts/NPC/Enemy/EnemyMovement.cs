using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 orginalEnemyPosition;
    private Quaternion orginalEnemyrotation;
    private NavMeshAgent agent;
    public BoolVariable playerInEnemyRange;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float turnRate;
    [SerializeField] private float distanceFromPlayer;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        orginalEnemyPosition = this.gameObject.transform.position;
        orginalEnemyrotation = this.transform.rotation;
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        if (!agent)
        {
            agent = this.gameObject.GetComponentInChildren<NavMeshAgent>();
        }
        
    }

    private void Awake()
    {
        playerInEnemyRange.ValueChanged.AddListener(startMovement);
    }

    private void OnDestroy()
    {
        playerInEnemyRange.ValueChanged.RemoveListener(startMovement);
    }

    private void FixedUpdate()
    {
        if (agent.velocity.magnitude > walkSpeed/2)
        {
            animator.SetBool("isMoving",true);
        }
        else if(agent.velocity.magnitude <= walkSpeed/2)
        {
            animator.SetBool("isMoving", false);
        }

        if (agent.hasPath)
        {
            if (agent.remainingDistance <= distanceFromPlayer)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }
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
            transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.fixedDeltaTime*turnRate);
        }
        if (agent.velocity == Vector3.zero && playerInEnemyRange.getValue())
        {
            Vector3 direction = (player.transform.position - agent.transform.position).normalized;
            direction.y = 0;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime*turnRate);
        }
    }
    
}
