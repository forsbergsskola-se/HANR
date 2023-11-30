using System;
using CustomObjects;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TempPlayerHealth : MonoBehaviour
    {
        public FloatVariable Health;
        private TextMeshProUGUI text;

        private void Awake()
        {
            Health.ValueChanged.AddListener(updateText);
            text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            Health.ValueChanged.RemoveListener(updateText);
        }

        private void updateText(float value)
        {
            text.text = "Health: " + value.ToString();
        }
    }
}