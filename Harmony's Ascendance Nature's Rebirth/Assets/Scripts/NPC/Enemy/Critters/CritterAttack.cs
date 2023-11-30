using CustomObjects;
using UnityEngine;

namespace Enemy.Critters
{
    public class CritterAttack : MonoBehaviour
    {
        public BoolVariable PlayerInAttackRange;
        [SerializeField]private Animator animator;
        
        private void Awake()
        {
            PlayerInAttackRange.ValueChanged.AddListener(meeleAttack);
        }
        
        private void OnDestroy()
        {

            PlayerInAttackRange.ValueChanged.RemoveListener(meeleAttack);
        }
        
        private void meeleAttack(bool inRange)
        {
            animator.SetBool("isInAttackRange",inRange);
        }
    }
}