using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.UseSkills
{
    public class SkillsPressed : MonoBehaviour
    {
        public UnityEvent<Skills> skillPressed;
    }
}