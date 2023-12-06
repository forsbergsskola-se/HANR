using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Player.UseSkills;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    private UsableItems usableItems;
    private SkillsPressed skillPressed;
    
    [SerializeField] private Image megaSkill;
    [SerializeField] private Image smallSkill;
    [SerializeField] private Image small2Skill;
    
    [SerializeField] private Sprite starterMega;
    [SerializeField] private Sprite starterSmall;
    [SerializeField] private Sprite starterSmall2;

    private Item item;
    
    void Start()
    {
        usableItems = GameObject.FindWithTag("Player").GetComponent<UsableItems>();
        skillPressed = GameObject.FindWithTag("Player").GetComponent<SkillsPressed>();
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

    private void ShowStarterSkills(Item i)
    {
        item = i;
        //TODO SHOW STARTERSKILLS SPRITES 
        megaSkill.sprite = starterMega;
        smallSkill.sprite = starterSmall;
        smallSkill.sprite = starterSmall2;
    }
    
    private void ShowFireSkills(Item i)
    {
        item = i;
        //TODO SHOW FIRESKILLS SPRITES
        megaSkill.sprite = i.ultiSkill.icon;
        smallSkill.sprite = i.skill1.icon;
        small2Skill.sprite = i.skill2.icon;
        megaSkill.color = Color.red;
    }

    private void ShowWaterSkills(Item i)
    {
        item = i;
        //TODO SHOW WATERSKILLS SPRITES
        megaSkill.sprite = i.ultiSkill.icon;
        smallSkill.sprite = i.skill1.icon;
        small2Skill.sprite = i.skill2.icon;
        megaSkill.color = Color.blue;
    }

    public void skill1Pressed()
    {
        skillPressed.skill1.Invoke(item.skill1);
    }
    
    public void skill2Pressed()
    {
        skillPressed.skill2.Invoke(item.skill2);
    }
    
    public void ultiSkiilPressed()
    {
        skillPressed.ultiSkill.Invoke(item.ultiSkill);
    }


}

