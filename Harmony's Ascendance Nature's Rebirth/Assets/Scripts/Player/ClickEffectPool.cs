using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ClickEffectPool : MonoBehaviour
    {
        public GameObject clickEffect;
        public int size;

        private List<GameObject> effectPool;

        private void Start()
        {
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
    }
    /*
    public GameObject GetPooledGameObject()
    {
        foreach(GameObject obj in effectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    } */
}