using UnityEngine;
using UnityEngine.Events;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "TargetPoint", menuName = "target", order = 0)]
    public class TargetPoint : ScriptableObject
    {
        public UnityEvent<Vector3> updateTargetPoint;
        private Vector3 targetPoint;

        public void SetValue(Vector3 newTarget)
        {
            targetPoint = newTarget;
            updateTargetPoint.Invoke(targetPoint);
        }

        public Vector3 GetValue()
        {
            return targetPoint;
        }
    }
}