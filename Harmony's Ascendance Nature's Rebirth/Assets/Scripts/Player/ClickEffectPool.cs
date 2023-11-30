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
        public BoolVariable effectUsed;

        private List<GameObject> effectPool;
        private bool timerActive;
        private bool isReturning;
        private float timerValue = 5f;

        private void Awake()
        {
            effectUsed.ValueChanged.AddListener(StartReturnToPool);
        }

        private void OnDestroy()
        {
            effectUsed.ValueChanged.RemoveListener(StartReturnToPool);
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

        private void StartReturnToPool(bool effectUsed)
        {
            StartCoroutine(Timer(timerValue));
            ReturnToPool(clickEffect);
            isReturning = false;
        }
        
        private void ReturnToPool(GameObject effect)
        {
            effect.SetActive(false);
        }
        
        
        private IEnumerator Timer(float value)
        {
            isReturning = true;
            float timer = value;
            
            while (timer > 0f)
            {
                yield return new WaitForSeconds(1f);
                timer -= 1f;
            }
            effectUsed.setValue(false);
        }
    }
}