using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class DefaultAttackPool : MonoBehaviour
    {
        public GameObject projectile;
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
                GameObject proj = Instantiate(projectile);
                proj.SetActive(false);
                projectilePool.Add(proj);
            }
        }
        
        public GameObject GetPooledEffects()
        {
            foreach (GameObject pooledProjectile in projectilePool)
            {
                if (!pooledProjectile.activeInHierarchy)
                {
                    pooledProjectile.SetActive(true);
                    return pooledProjectile;
                }
            }
            return null;
        }
    }
}