using UnityEngine;

namespace OCP._Source.Attack.Strategies
{
    public class StraightStrategy : MonoBehaviour, IAttackStrategy
    {
        [SerializeField] private Animator animator;
        
        private readonly int straightAttackHash = Animator.StringToHash("Straight");
        
        public void Attack()
        {
            animator.SetTrigger(straightAttackHash);
        }
    }
}