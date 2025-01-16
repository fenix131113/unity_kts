using UnityEngine;

namespace OCP._Source.Attack.Strategies
{
    public class BraidStrategy : IAttackStrategy
    {
        private readonly Animator _animator;
        
        private readonly int braidAttackHash = Animator.StringToHash("Braid");

        public BraidStrategy(Animator anim) => _animator = anim;

        public void Attack()
        {
            _animator.SetTrigger(braidAttackHash);
        }
    }
}