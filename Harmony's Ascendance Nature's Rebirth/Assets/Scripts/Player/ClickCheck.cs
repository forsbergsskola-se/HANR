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
                        playerAttacking.setValue(false);
                    }
                    if (raycastHit.transform.CompareTag("Enemy"))
                    {
                        playerMoving.setValue(false);
                        playerAttacking.setValue(true);
                    }
                }
            }
        }
    }
}
