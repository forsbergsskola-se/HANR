using System;
using CustomObjects;
using UnityEngine;

namespace Enviromental
{
    public class WinEffects : MonoBehaviour
    {
        public BoolVariable isBossKilled;
        
        public GameObject battleEffects;
        public GameObject winEffects;

        private void Awake()
        {
            isBossKilled.ValueChanged.AddListener(ChangeToWinEffects);
            winEffects.SetActive(false);
        }

        private void OnDestroy()
        {
            isBossKilled.ValueChanged.RemoveListener(ChangeToWinEffects);
        }

        private void ChangeToWinEffects(bool isBossKilled)
        {
            if (this.isBossKilled)
            {
                battleEffects.SetActive(false);
                winEffects.SetActive(true);
            }
            
        }
    }
}