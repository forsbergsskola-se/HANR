using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class HitEffectPool : MonoBehaviour
    {
        public GameObject hitEffect;
        public int size = 5;

        private List<GameObject> hitEffectPool;
        
        private void Start()
        {
            hitEffectPool = new List<GameObject>();
            SetUpPool();
        }

        private void SetUpPool()
        {
            for (int i = 0; i < size; i++)
            {
                GameObject effect = Instantiate(hitEffect);
                effect.SetActive(false);
                hitEffectPool.Add(effect);
            }
        }

        public GameObject GetPooledEffects()
        {
            foreach (GameObject effect in hitEffectPool)
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