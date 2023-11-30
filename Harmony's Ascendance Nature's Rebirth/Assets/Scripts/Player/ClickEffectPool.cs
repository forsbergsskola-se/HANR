using System;
using System.Collections;
using System.Collections.Generic;
using CustomObjects;
using UnityEngine;

namespace Player
{
    public class ClickEffectPool : MonoBehaviour
    {
        public GameObject clickEffect;
        public int size = 5;
        public BoolVariable EffectUsed;

        private List<GameObject> effectPool;
        private bool timerActive;

        private void Awake()
        {
            //EffectUsed.ValueChanged.AddListener();
        }

        private void OnDestroy()
        {
            //EffectUsed.ValueChanged.RemoveListener();
        }

        private void Start()
        {
            effectPool = new List<GameObject>();
            SetUpPool();
        }

        private void SetUpPool()
        {
            for (int i = 0; i < size; i++)
            {
                GameObject effect = Instantiate(clickEffect);
                effect.SetActive(false);
                effectPool.Add(effect);
            }
        }

        public GameObject GetPooledEffects()
        {
            foreach (GameObject effect in effectPool)
            {
                if (!effect.activeInHierarchy)
                {
                    effect.SetActive(true);
                    return effect;
                }
            }
            return null;
        }
        
        public void ReturnToPool(GameObject effect)
        {
            effect.SetActive(false);
        }
        
        
        private IEnumerator Timer(float Value)
        {
            timerActive = true;
            float timer = Value;
            
            while (timer > 0f)
            {
                yield return new WaitForSeconds(1f);
                timer -= 1f;
            }
            timerActive = false;
            EffectUsed.setValue(false);
        }
    }
}