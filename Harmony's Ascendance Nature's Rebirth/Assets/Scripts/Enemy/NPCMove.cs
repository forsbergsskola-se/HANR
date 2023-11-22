using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private Transform player;
    private Transform pos1;
    private Transform pos2;
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        pos1 = transform.Find("pos1");
        pos2 = transform.Find("pos2");
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        WalkToPos();
    }
    
    private void WalkToPos()
    {
        if (navMeshAgent.velocity == Vector3.zero)
        {
            navMeshAgent.destination = pos1.position;
        }
        
    }
    
}
