using UnityEngine;

namespace CustomObjects
{
    [CreateAssetMenu(fileName = "CombatStatEnemyBoss", menuName = "SO/CombatStatEnemyBoss", order = 0)]
    public class CombatStatEnemyBoss : ScriptableObject
    {
        public float rockAttackDamage;
        public float normalAttackDamage;
        public float normalAttackSpeed;
        public float rockAttackCooldown;

    }
}