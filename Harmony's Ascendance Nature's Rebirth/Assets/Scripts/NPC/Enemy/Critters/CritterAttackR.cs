using CustomObjects;
using UnityEngine;

namespace Enemy.Critters
{
    public class CritterAttackR : MonoBehaviour
    {
        public BoolVariable PlayerInAttackRangeR;
        [SerializeField]private Animator animator;
        
        private void Awake()
        {
            PlayerInAttackRangeR.ValueChanged.AddListener(MeeleAttack);
        }
        
        private void OnDestroy()
        {

            PlayerInAttackRangeR.ValueChanged.RemoveListener(MeeleAttack);
        }
        
        private void MeeleAttack(bool PlayerInAttackRangeR)
        {
            animator.SetBool("isInAttackRange", PlayerInAttackRangeR);
        }
    }
}