using UnityEngine;
using UnityEngine.Events;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "SO/GameObjectVariable", order = 0)]
    public class GameObjectVariable : ScriptableObject
    {
        public UnityEvent<GameObject> ValueChanged;
        private GameObject value = null;

        public void setValue(GameObject newValue)
        {
            value = newValue;
            ValueChanged.Invoke(value);
        }

        public GameObject getValue()
        {
            return value;
        }
    }
}