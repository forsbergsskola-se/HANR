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

        private List<GameObject> effectPool;
        
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
    }
}