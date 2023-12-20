using CustomObjects;
using UnityEngine;

namespace Enemy.Critters
{
    public class CritterAttackP : MonoBehaviour
    {
        public BoolVariable PlayerInAttackRangeP;
        [SerializeField]private Animator animator;
        
        private void Awake()
        {
            PlayerInAttackRangeP.ValueChanged.AddListener(meeleAttack);
        }
        
        private void OnDestroy()
        {

            PlayerInAttackRangeP.ValueChanged.RemoveListener(meeleAttack);
        }
        
        private void meeleAttack(bool PlayerInAttackRangeP)
        {
            animator.SetBool("isInAttackRange",PlayerInAttackRangeP);
        }
    }
}