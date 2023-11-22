using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
   
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        navMeshAgent.destination = transform.position - player.position;
    }
}
