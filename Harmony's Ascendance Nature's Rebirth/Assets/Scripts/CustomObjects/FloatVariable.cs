using UnityEngine;
using UnityEngine.Events;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "SO/FloatVariable", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        public UnityEvent<float> ValueChanged;
        private float value;

        public void setValue(float newValue)
        {
            value = newValue;
            ValueChanged.Invoke(value);
        }

        public float getValue()
        {
            return value;
        }
    }
}