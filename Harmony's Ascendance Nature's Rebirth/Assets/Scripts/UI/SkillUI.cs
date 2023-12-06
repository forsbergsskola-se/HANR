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
    
    
    void Start()
    {
        usableItems = GameObject.FindWithTag("Player").GetComponent<UsableItems>();

        //Add them listeners!
        usableItems.startStaffEquipped.AddListener(ShowStarterSkills);
        usableItems.fireStaffEquipped.AddListener(ShowFireSkills);
        usableItems.waterStaffEquipped.AddListener(ShowWaterSkills);
        
        Color color = megaSkill.color;
        color.a = 0f;
        megaSkill.color = color;
        small2Skill.color = color;
        smallSkill.color = color;
    }


    private void OnDestroy()
    {
        //Remove them listeners!
        usableItems.startStaffEquipped.RemoveListener(ShowStarterSkills);
        usableItems.fireStaffEquipped.RemoveListener(ShowFireSkills);
        usableItems.waterStaffEquipped.RemoveListener(ShowWaterSkills);
    }

    private void ShowStarterSkills(Item item)
    {
        //TODO SHOW STARTERSKILLS SPRITES 
        megaSkill.sprite = starterMega;
        smallSkill.sprite = starterSmall;
        smallSkill.sprite = starterSmall2;
    }
    
    private void ShowFireSkills(Item item)
    {
        //TODO SHOW FIRESKILLS SPRITES
        megaSkill.sprite = item.ultiSkill.icon;
        smallSkill.sprite = item.skill1.icon;
        small2Skill.sprite = item.skill2.icon;
        megaSkill.color = Color.red;
    }

    private void ShowWaterSkills(Item item)
    {
        //TODO SHOW WATERSKILLS SPRITES
        megaSkill.sprite = item.ultiSkill.icon;
        smallSkill.sprite = item.skill1.icon;
        small2Skill.sprite = item.skill2.icon;
        megaSkill.color = Color.blue;
    }


}

