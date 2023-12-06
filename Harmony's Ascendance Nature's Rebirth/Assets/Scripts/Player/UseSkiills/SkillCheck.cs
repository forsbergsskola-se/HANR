using System;
using UnityEngine;
using UnityEngine.Events;
using CustomObjects;
namespace Player.UseSkills
{
    public class SkillCheck : MonoBehaviour
    {
        private SkillUI skillUI;
        private GameObject weaponEquipped;
        private void Start()
        {
            skillUI.skill1.AddListener(skill1Used);
            skillUI.skill2.AddListener(skill2Used);
            skillUI.ultiSkill.AddListener(ultiSkillUsed);
            weaponEquipped = this.gameObject.GetComponentInChildren<WeaponEquipped>().gameObject;
        }

        private void OnDestroy()
        {
            skillUI.skill1.RemoveListener(skill1Used);
            skillUI.skill2.RemoveListener(skill2Used);
            skillUI.ultiSkill.RemoveListener(ultiSkillUsed);
        }
        
        private void skill1Used(Skills skill)
        {
            if (skill.pointClick)
            {
                
            }
            else
            {
                
            }
        }
        
        private void skill2Used(Skills skill)
        {
            if (skill.pointClick)
            {
                
            }
            else
            {
                
            }
        }
        
        private void ultiSkillUsed(Skills skill)
        {
            if (skill.pointClick)
            {
                
            }
            else
            {
                
            }
        }
    }
}