using UnityEngine;
using UnityEngine.Events;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "SO/BoolVariable", order = 0)]
    public class BoolVariable : ScriptableObject
    {
        public UnityEvent<bool> ValueChanged;
        private bool value;

        public void setValue(bool newValue)
        {
            value = newValue;
            ValueChanged.Invoke(value);
        }

        public bool getValue()
        {
            return value;
        }
    }
}