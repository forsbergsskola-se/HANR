using System;
using CustomObjects;
using UnityEngine;

namespace Player
{
    public class PlayerStat : MonoBehaviour
    {
        public FloatVariable health;
        public float maxHealth;
        public FloatVariable magic;
        public float maxMagic;
        public FloatVariable exp;
        public float maxExp;
        public IntVariable level;
        
        private void Start()
        {
            //Starting stats when starting play-mode
            health.setValue(90f);
            maxHealth = 100f;
            magic.setValue(50.5f);
            maxMagic = 100f;
            exp.setValue(90.5f);
            maxExp = 100f;
            level.setValue(15);
            
            health.ValueChanged.AddListener(LimiterStat);
            magic.ValueChanged.AddListener(LimiterStat);
            exp.ValueChanged.AddListener(LevelUp);
        }
        private void OnDestroy()
        {
            health.ValueChanged.RemoveListener(LimiterStat);
            magic.ValueChanged.RemoveListener(LimiterStat);
            exp.ValueChanged.RemoveListener(LevelUp);
        }
        private void LevelUp(float currentLevel)
        {
            if (exp.getValue() > maxExp)
            {
                float newExp = exp.getValue() - maxExp;
                int newLevel = level.getValue() + 1;
                level.setValue(newLevel);
                exp.setValue(newExp);
                /*maxExp =+ 30f; //Increasing requirement for next level
                maxHealth =+ 20f;
                maxMagic =+ 60f;*/
            }
        }
        private void LimiterStat(float currentValues)
        {
            if(health.getValue() > maxHealth) health.setValue(maxHealth);
            if(magic.getValue() > maxMagic) magic.setValue(maxMagic);
        }
    }
}