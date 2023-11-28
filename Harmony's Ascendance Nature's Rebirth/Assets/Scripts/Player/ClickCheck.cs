using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class ClickCheck : MonoBehaviour
{
    public BoolVariable playerMoving;
    public BoolVariable playerAttacking;
    public TargetPoint targetPoint;
    
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
                    targetPoint.SetValue(raycastHit.point);
                    
                    if (raycastHit.transform.CompareTag("Ground"))
                    {
                        playerMoving.setValue(true);
                    }
                    if (raycastHit.transform.CompareTag("Enemy"))
                    {
                        playerAttacking.setValue(true);
                    }

                    if (raycastHit.transform.CompareTag("Item"))
                    {
                        // Filip, säg till nästa gång du vill ändra i script som någon jobbar i =)
                    }
                }
            }
        }
    }
}
