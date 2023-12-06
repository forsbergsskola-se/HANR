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
    private SkillsPressed skillPressed;
    private UsableItems usableItems;
    private ClickEffectPool clickEffectPool;
    private ClickOnEnemyPool clickOnEnemyPool;
    private Camera _camera;
    private Item item;

    private void Start()
    {
        _camera = Camera.main;
        clickEffectPool = this.gameObject.GetComponent<ClickEffectPool>();
        clickOnEnemyPool = this.gameObject.GetComponent<ClickOnEnemyPool>();
        skillPressed = this.gameObject.GetComponent<SkillsPressed>();
        usableItems = this.gameObject.GetComponent<UsableItems>();
        usableItems.startStaffEquipped.AddListener(SetItemStarterStaff);
        usableItems.fireStaffEquipped.AddListener(SetItemFireStaff);
        usableItems.waterStaffEquipped.AddListener(SetItemWaterStaff);
    }

    private void OnDestroy()
    {
        usableItems.startStaffEquipped.RemoveListener(SetItemStarterStaff);
        usableItems.fireStaffEquipped.RemoveListener(SetItemFireStaff);
        usableItems.waterStaffEquipped.RemoveListener(SetItemWaterStaff);
    }

    private void SetItemStarterStaff(Item arg0)
    {
        item = arg0;
    }

    private void SetItemFireStaff(Item arg0)
    {
        item = arg0;
    }

    private void SetItemWaterStaff(Item arg0)
    {
        item = arg0;
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
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
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
                            effectInstance.transform.position = raycastHit.point += new Vector3(0,0.3f,0);
                        }
                    }
                }
            }
        } 
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            skillPressed.skill1.Invoke(item.skill1);
        }  
        else if (Input.GetKeyDown(KeyCode.W))
        {
            skillPressed.skill2.Invoke(item.skill2);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            skillPressed.ultiSkill.Invoke(item.ultiSkill);
        }
    }
}
