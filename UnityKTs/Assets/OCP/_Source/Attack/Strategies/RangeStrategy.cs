using UnityEngine;

namespace OCP._Source.Attack.Strategies
{
    public class RangeStrategy : MonoBehaviour, IAttackStrategy
    {
        [SerializeField] private Animator animator;
        
        private readonly int rangeAttackHash = Animator.StringToHash("Range");
        
        public void Attack()
        {
            animator.SetTrigger(rangeAttackHash);
        }
    }
}