using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    private UsableItems usableItems;
    
    [SerializeField] private SpriteRenderer megaSkill;
    [SerializeField] private SpriteRenderer smallSkill;
    [SerializeField] private SpriteRenderer small2Skill;
    
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
    }
    
    private void ShowFireSkills()
    {
        //TODO SHOW FIRESKILLS SPRITES
    }

    private void ShowWaterSkills()
    {
        //TODO SHOW WATERSKILLS SPRITES
    }


}

