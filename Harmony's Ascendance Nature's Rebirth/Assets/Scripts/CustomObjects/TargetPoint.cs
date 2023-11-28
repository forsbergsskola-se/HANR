using UnityEngine;
using UnityEngine.Events;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "TargetPiont", menuName = "target", order = 0)]
    public class TargetPoint : ScriptableObject
    {
        public UnityEvent<Vector3> UpdateTargetPoint;
        private Vector3 targetPoint;

        public void SetValue(Vector3 newTarget)
        {
            targetPoint = newTarget;
            UpdateTargetPoint.Invoke(targetPoint);
        }

        public Vector3 GetValue()
        {
            return targetPoint;
        }
    }
}