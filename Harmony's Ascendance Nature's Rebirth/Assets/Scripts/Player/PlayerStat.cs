using System;
using CustomObjects;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

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
        public GameManagerScript gameOverScreen;
        public GameObject deathEffect;
       
        private void Start()
        {
            //Starting stats when starting play-mode
            health.setValue(10f);
            maxHealth = 100f;
            magic.setValue(50.5f);
            maxMagic = 100f;
            exp.setValue(90.5f);
            maxExp = 100f;
            level.setValue(15);
            
            health.ValueChanged.AddListener(LimiterHealth);
            magic.ValueChanged.AddListener(LimiterMagic);
            exp.ValueChanged.AddListener(LevelUp);
        }
        private void OnDestroy()
        {
            health.ValueChanged.RemoveListener(LimiterHealth);
            magic.ValueChanged.RemoveListener(LimiterMagic);
            exp.ValueChanged.RemoveListener(LevelUp);
        }
        private void LevelUp(float currentLevel)
        {
            if (exp.getValue() > maxExp)
            {
                exp.setValue(exp.getValue() - maxExp);
                level.setValue(level.getValue() + 1);
                SFX.SoundManager.PlaySound("Level Up");
                
                maxExp += 30f; //Increasing requirement for next level
                maxHealth += 20f;
                maxMagic += 60f;
            }
        }
        private void LimiterHealth(float currentValues) //Limiter for health
        {
            if(currentValues > maxHealth) health.setValue(maxHealth);
            if (health.getValue() <= 0f)
            {
                DeathEffect();
                gameOverScreen.gameObject.SetActive(true);
            }
           
        }
        private void LimiterMagic(float currentValues) //Limiter for magic
        {
            if(currentValues > maxMagic) magic.setValue(maxMagic);
        }
        
        private void DeathEffect()
        {
            GameObject effect  = Instantiate(deathEffect, this.transform);
            effect.transform.position = this.transform.position;
            
            StartCoroutine(removeObjects(effect));
        }

        private IEnumerator removeObjects(GameObject effect)
        {
            yield return new WaitForSeconds(3);
            Destroy(effect);
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
        }

        
    }
}