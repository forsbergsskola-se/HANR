using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.BossEnemy
{
    public class RockObjectPool : MonoBehaviour
    {
        public GameObject pooledObject;
        public int size = 3;

        private List<GameObject> objectpool = new List<GameObject>();

        private void Start()
        {
            CreatePool();
        }

        private void CreatePool()
        {
            for (int i = 0; i < size; i++)
            {
                GameObject obj = Instantiate(pooledObject);
                obj.SetActive(false);
                objectpool.Add(obj);
            }
        }

        public GameObject GetPooledGameObject()
        {
            foreach(GameObject obj in objectpool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            return null;
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}