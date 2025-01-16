using UnityEngine;

namespace OCP._Source.Attack.Strategies
{
    public class BraidStrategy : MonoBehaviour, IAttackStrategy
    {
        [SerializeField] private Animator animator;
        
        private readonly int braidAttackHash = Animator.StringToHash("Braid");
        
        public void Attack()
        {
            animator.SetTrigger(braidAttackHash);
        }
    }
}