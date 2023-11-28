using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class ClickCheck : MonoBehaviour
{
    public UnityEvent<RaycastHit> MovePlayer;
    public UnityEvent<RaycastHit> AttackEnemy;
    public RaycastHit rayHit;
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;
    public GameObject itemPickUp;

    private void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (raycastHit.transform.CompareTag("Ground"))
                    {
                        rayHit = raycastHit;
                        playerMovement = GetComponent<PlayerMovement>();
                        playerMovement.MoveToClick(rayHit);
                        playerMovement.RotateToClick();
                    }
                    if (raycastHit.transform.CompareTag("Enemy"))
                    {
                        rayHit = raycastHit;
                        playerAttack = GetComponent<PlayerAttack>();
                        playerAttack.AttackEnemy(rayHit);
                    }

                    if (raycastHit.transform.CompareTag("Item"))
                    {
                        
                    }
                }
            }
        }
    }
}
