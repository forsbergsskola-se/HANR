using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    private UsableItems usableItems;
    
    [SerializeField] private Image megaSkill;
    [SerializeField] private Image smallSkill;
    [SerializeField] private Image small2Skill;
    
    [SerializeField] private Sprite starterMega;
    [SerializeField] private Sprite starterSmall;
    [SerializeField] private Sprite starterSmall2;
    
    [SerializeField] private Sprite fireMega;
    [SerializeField] private Sprite fireSmall1;
    [SerializeField] private Sprite fireSmall2;
    
    [SerializeField] private Sprite waterMega;
    [SerializeField] private Sprite waterSmall1;
    [SerializeField] private Sprite waterSmall2;
    
    void Start()
    {
        usableItems = GameObject.FindWithTag("Player").GetComponent<UsableItems>();

        //Add them listeners!
        usableItems.startStaffEquipped.AddListener(ShowStarterSkills);
        usableItems.fireStaffEquipped.AddListener(ShowFireSkills);
        usableItems.waterStaffEquipped.AddListener(ShowWaterSkills);
    }


    private void OnDestroy()
    {
        //Remove them listeners!
        usableItems.startStaffEquipped.RemoveListener(ShowStarterSkills);
        usableItems.fireStaffEquipped.RemoveListener(ShowFireSkills);
        usableItems.waterStaffEquipped.RemoveListener(ShowWaterSkills);
    }

    private void ShowStarterSkills()
    {
        //TODO SHOW STARTERSKILLS SPRITES 
        megaSkill.sprite = starterMega;
        smallSkill.sprite = starterSmall;
        smallSkill.sprite = starterSmall2;
    }
    
    private void ShowFireSkills()
    {
        //TODO SHOW FIRESKILLS SPRITES
        megaSkill.sprite = fireMega;
        smallSkill.sprite = fireSmall1;
        small2Skill.sprite = fireSmall2;
    }

    private void ShowWaterSkills()
    {
        //TODO SHOW WATERSKILLS SPRITES
        megaSkill.sprite = waterMega;
        smallSkill.sprite = waterSmall1;
        small2Skill.sprite = waterSmall2;
    }


}

