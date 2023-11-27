using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCheck : MonoBehaviour
{
    public UnityEvent MovePlayer;
    public UnityEvent AttackEnemy;
    
    private void LateUpdate()
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
                    if (raycastHit.transform.CompareTag("Ground")) //Invoke MovePlayer event
                    {
                        MovePlayer.Invoke(raycastHit);
                    }
                    if (raycastHit.transform.CompareTag("Enemy")) //Invoke AttackEnemy event
                    {
                        AttackEnemy.Invoke(raycastHit);
                    }
                }
            }
        }
    }
}
