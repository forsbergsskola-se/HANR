using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.UseSkills
{
    public class SkillsPressed : MonoBehaviour
    {
        public UnityEvent<Skills> skill1;
        public UnityEvent<Skills> skill2;
        public UnityEvent<Skills> ultiSkill;
        private UsableItems usableItems;
        private Item item;


        private void Start()
        {
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                skill1.Invoke(item.skill1);
            }  
            else if (Input.GetKeyDown(KeyCode.W))
            {
                skill2.Invoke(item.skill2);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ultiSkill.Invoke(item.ultiSkill);
            }
        }
    }
}