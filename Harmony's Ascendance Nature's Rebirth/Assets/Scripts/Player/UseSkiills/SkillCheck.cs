using System;
using UnityEngine;
using UnityEngine.Events;
using CustomObjects;
namespace Player.UseSkills
{
    public class SkillCheck : MonoBehaviour
    {
        private SkillsPressed skillsPressed;
        private GameObject weaponEquipped;
        private void Start()
        {
            skillsPressed = this.gameObject.GetComponent<SkillsPressed>();
            skillsPressed.skill1.AddListener(skill1Used);
            skillsPressed.skill2.AddListener(skill2Used);
            skillsPressed.ultiSkill.AddListener(ultiSkillUsed);
            weaponEquipped = this.gameObject.GetComponentInChildren<WeaponEquipped>().gameObject;
        }

        private void OnDestroy()
        {
            skillsPressed.skill1.RemoveListener(skill1Used);
            skillsPressed.skill2.RemoveListener(skill2Used);
            skillsPressed.ultiSkill.RemoveListener(ultiSkillUsed);
        }
        
        private void skill1Used(Skills skill)
        {
            if (skill.pointClick)
            {
                Debug.Log("skill1");
            }
            else
            {
                
            }
        }
        
        private void skill2Used(Skills skill)
        {
            if (skill.pointClick)
            {
                Debug.Log("skill2");
            }
            else
            {
                
            }
        }
        
        private void ultiSkillUsed(Skills skill)
        {
            if (skill.pointClick)
            {
                Debug.Log("ulti skill pressed player");
                Debug.Log(weaponEquipped.transform.position);
                GameObject temp = Instantiate(skill.skillObject, weaponEquipped.transform);
                temp.transform.position = weaponEquipped.transform.position;
            }
            else
            {
                
            }
        }
    }
}