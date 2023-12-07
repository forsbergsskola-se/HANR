using UnityEngine;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "CombatStat", menuName = "SO/CombatStat", order = 0)]
    public class CombatStat : ScriptableObject
    {
        public float damage;
        public float projectileSpeed;
        public float attackRate;
        public float range;
        public Material material;
        public Color hitEffectColor;
    }
}