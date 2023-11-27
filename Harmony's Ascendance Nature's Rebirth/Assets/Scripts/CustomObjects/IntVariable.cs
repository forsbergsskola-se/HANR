using UnityEngine;
using UnityEngine.Events;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "SO/IntVariable", order = 1)]
    public class IntVariable : ScriptableObject
    {
        public UnityEvent<int> ValueChanged;
        private int value;

        public void setValue(int newValue)
        {
            value = newValue;
            ValueChanged.Invoke(value);
        }

        public int getValue()
        {
            return value;
        }
    }
}