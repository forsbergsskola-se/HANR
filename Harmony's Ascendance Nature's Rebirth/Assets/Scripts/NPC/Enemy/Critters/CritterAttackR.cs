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
            PlayerInAttackRangeR.ValueChanged.AddListener(meeleAttack);
        }
        
        private void OnDestroy()
        {

            PlayerInAttackRangeR.ValueChanged.RemoveListener(meeleAttack);
        }
        
        private void meeleAttack(bool inRange)
        {
            animator.SetBool("isInAttackRange",inRange);
        }
    }
}