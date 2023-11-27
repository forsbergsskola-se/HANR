using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickCheck : MonoBehaviour
{
    //public UnityEvent<RaycastHit> MovePlayer;
    public UnityEvent AttackEnemy = new UnityEvent();
    public RaycastHit rey;
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
                Debug.Log("Yes Cam");
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (raycastHit.transform.CompareTag("Ground")) //Invoke MovePlayer event
                    {
                        //MovePlayer.Invoke(raycastHit);
                        Debug.Log("Yes Hit");
                        rey = raycastHit;

                    }
                    if (raycastHit.transform.CompareTag("Enemy")) //Invoke AttackEnemy event
                    {
                        AttackEnemy.Invoke();
                        Debug.Log("Yes Hit");

                    }
                }
            }
        }
    }
}
