using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CllickOnEnemyEffect : MonoBehaviour
    {
        public GameObject clickEffect;
        public int size = 5;

        private List<GameObject> enemyEffectPool;
        
        private void Start()
        {
            enemyEffectPool = new List<GameObject>();
            SetUpPool();
        }

        private void SetUpPool()
        {
            for (int i = 0; i < size; i++)
            {
                GameObject effect = Instantiate(clickEffect);
                effect.SetActive(false);
                enemyEffectPool.Add(effect);
            }
        }

        public GameObject GetPooledEffects()
        {
            foreach (GameObject effect in enemyEffectPool)
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
