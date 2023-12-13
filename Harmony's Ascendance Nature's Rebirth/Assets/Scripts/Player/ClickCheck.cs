using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using Player;
using Player.UseSkills;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ClickCheck : MonoBehaviour
{
    public BoolVariable playerMoving;
    public TargetPoint targetPoint;
    public GameObjectVariable currentClickedEnemy;
    private ClickEffectPool clickEffectPool;
    private ClickOnEnemyPool clickOnEnemyPool;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        clickEffectPool = this.gameObject.GetComponent<ClickEffectPool>();
        clickOnEnemyPool = this.gameObject.GetComponent<ClickOnEnemyPool>();
    }

    private void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_camera)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                int layerMask = ~LayerMask.GetMask(layerNames: new[] { "NPC", "Item" }); // To ignore colliders of items and NPC:s
                if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
                {
                    targetPoint.SetValue(raycastHit.point);
                    
                    if (raycastHit.transform.CompareTag("Ground"))
                    {
                        playerMoving.setValue(true);
                        currentClickedEnemy.setValue(null);
                        
                        GameObject effectInstance = clickEffectPool.GetPooledEffects();
                        if (effectInstance != null)
                        {
                            effectInstance.transform.position = raycastHit.point += new Vector3(0,0.3f,0);
                        }
                    }
                    if (raycastHit.transform.CompareTag("Enemy"))
                    {
                        currentClickedEnemy.setValue(raycastHit.transform.gameObject);
                        GameObject effectInstance = clickOnEnemyPool.GetPooledEffects();
                        if (effectInstance != null)
                        {
                            effectInstance.transform.position = raycastHit.transform.gameObject.transform.position;
                            effectInstance.transform.localScale = Vector3.one * 4f;
                        }
                    }
                }
            }
        } 
    }
}
