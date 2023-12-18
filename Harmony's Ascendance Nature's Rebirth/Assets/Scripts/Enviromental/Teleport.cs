using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navMeshAgent;

    public Instructions instructions;
    
    public Transform tpPosition;

    private bool Inside;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        navMeshAgent = player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Inside && Input.GetKeyDown(KeyCode.T))
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        // Check if the NavMeshAgent is active
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
        {
            // Disable NavMeshAgent before teleporting
            navMeshAgent.enabled = false;

            // Set the player's position and rotation
            player.transform.position = tpPosition.position;
            player.transform.rotation = Quaternion.LookRotation(tpPosition.forward, Vector3.up);

            // Enable NavMeshAgent after teleporting
            navMeshAgent.enabled = true;

            // Update the agent's position and destination
            navMeshAgent.Warp(tpPosition.position);
            navMeshAgent.SetDestination(tpPosition.position);
        }
        else
        {
            Debug.LogWarning("NavMeshAgent is not active or not attached.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        instructions.gameObject.SetActive(true);
        instructions.buttonInput.Invoke("Teleport");
        Inside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        instructions.gameObject.SetActive(false);
        Inside = false;
    }
}