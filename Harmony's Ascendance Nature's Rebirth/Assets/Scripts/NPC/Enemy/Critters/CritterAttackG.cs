using CustomObjects;
using UnityEngine;

namespace Enemy.Critters
{
    public class CritterAttackG : MonoBehaviour
    {
        public BoolVariable PlayerInAttackRangeG;
        [SerializeField]private Animator animator;
        
        private void Awake()
        {
            PlayerInAttackRangeG.ValueChanged.AddListener(meeleAttack);
        }
        
        private void OnDestroy()
        {

            PlayerInAttackRangeG.ValueChanged.RemoveListener(meeleAttack);
        }
        
        private void meeleAttack(bool inRange)
        {
            animator.SetBool("isInAttackRange",inRange);
        }
    }
}