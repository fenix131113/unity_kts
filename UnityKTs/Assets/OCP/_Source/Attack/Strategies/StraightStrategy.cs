using UnityEngine;

namespace OCP._Source.Attack.Strategies
{
    public class StraightStrategy : IAttackStrategy
    {
        private readonly Animator _animator;
        private readonly int straightAttackHash = Animator.StringToHash("Straight");
        
        public StraightStrategy(Animator anim) => _animator = anim;
        
        public void Attack()
        {
            _animator.SetTrigger(straightAttackHash);
        }
    }
}