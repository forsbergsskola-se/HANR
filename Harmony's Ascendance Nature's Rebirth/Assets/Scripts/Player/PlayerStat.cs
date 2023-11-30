using System;
using CustomObjects;
using UnityEngine;

namespace Player
{
    public class PlayerStat : MonoBehaviour
    {
        public FloatVariable Health;

        private void Start()
        {
            Health.setValue(100f);
        }
    }
}