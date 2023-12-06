using System;
using CustomObjects;
using UnityEngine;

namespace Player
{
    public class PlayerStat : MonoBehaviour
    {
        public FloatVariable health;
        public FloatVariable magic;
        public FloatVariable exp;
        public IntVariable level;
        
        private void Start()
        {
            health.setValue(40f);
            magic.setValue(50.5f);
            exp.setValue(65.5f);
            level.setValue(15);
        }
    }
}