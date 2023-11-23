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
    [SerializeField] private NavMeshAgent agent;
    public BoolVariable playerInEnemyRange;
    [SerializeField] private float walkSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        orginalEnemyPosition = this.gameObject.transform.position;
    }

    private void Awake()
    {
        playerInEnemyRange.ValueChanged.AddListener(startMovement);
    }

    private void OnDestroy()
    {
        playerInEnemyRange.ValueChanged.RemoveListener(startMovement);
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
    
}
