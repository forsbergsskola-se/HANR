using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class DefaultAttackPool : MonoBehaviour
    {
        public GameObject daEffect;
        public int size;

        private List<GameObject> daEffectPool;

        private void Start()
        {
            daEffectPool = new List<GameObject>();
            SetUpPool();
        }
        
        private void SetUpPool()
        {
            for (int i = 0; i < size; i++)
            {
                GameObject effect = Instantiate(daEffect);
                effect.SetActive(false);
                daEffectPool.Add(effect);
            }
        }
        
        public GameObject GetPooledEffects()
        {
            foreach (GameObject effect in daEffectPool)
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