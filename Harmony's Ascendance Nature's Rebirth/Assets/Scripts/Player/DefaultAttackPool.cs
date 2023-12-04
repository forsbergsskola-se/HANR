using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class DefaultAttackPool : MonoBehaviour
    {
        public GameObject Projectile;
        public int size;

        private List<GameObject> projectilePool;

        private void Start()
        {
            projectilePool = new List<GameObject>();
            SetUpPool();
        }
        
        private void SetUpPool()
        {
            for (int i = 0; i < size; i++)
            {
                GameObject proj = Instantiate(Projectile);
                proj.SetActive(false);
                projectilePool.Add(proj);
            }
        }
        
        public GameObject GetPooledEffects()
        {
            foreach (GameObject effect in projectilePool)
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