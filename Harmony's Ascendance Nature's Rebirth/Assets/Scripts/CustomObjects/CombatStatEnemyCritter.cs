using UnityEngine;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "CombatStatEnemyCritter", menuName = "SO/CombatStatEnemyCritter", order = 0)]
    public class CombatStatEnemyCritter : ScriptableObject
    {
        public float normalAttackDamage;
        public float normalAttackSpeed;
    }
}