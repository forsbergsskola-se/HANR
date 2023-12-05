using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ClickCheck : MonoBehaviour
{
    public BoolVariable playerMoving;
    public TargetPoint targetPoint;
    public GameObjectVariable currentClickedEnemy;
    
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
                        currentClickedEnemy.setValue(null);
                    }
                    if (raycastHit.transform.CompareTag("Enemy"))
                    {
                            currentClickedEnemy.setValue(raycastHit.transform.gameObject);
                    }
                }
            }
        }
    }
}
