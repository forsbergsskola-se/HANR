using UnityEngine;
using UnityEngine.Events;

namespace Player.UseSkills
{
    public class SkillsPressed : MonoBehaviour
    {
        public UnityEvent<Skills> skill1;
        public UnityEvent<Skills> skill2;
        public UnityEvent<Skills> ultiSkill;
    }
}