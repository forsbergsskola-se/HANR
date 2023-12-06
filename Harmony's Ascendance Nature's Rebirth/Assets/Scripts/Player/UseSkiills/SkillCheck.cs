using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using CustomObjects;
using UnityEngine.UIElements;

namespace Player.UseSkills
{
    public class SkillCheck : MonoBehaviour
    {
        private SkillsPressed skillsPressed;
        public BoolVariable skillActive;
        private void Start()
        {
            skillsPressed = this.gameObject.GetComponent<SkillsPressed>();
            skillsPressed.skillPressed.AddListener(SkillUsed);
        }

        private void OnDestroy()
        {
            skillsPressed.skillPressed.RemoveListener(SkillUsed);
        }
        
        private void SkillUsed(Skills skill)
        {
            if (skill.pointClick)
            {
                PointClick pc = this.gameObject.AddComponent<PointClick>();
                pc.skill = skill;
            }
            else
            {
                
            }
        }
        
    }
}