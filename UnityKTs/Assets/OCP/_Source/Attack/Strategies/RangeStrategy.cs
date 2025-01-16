using UnityEngine;

namespace OCP._Source.Attack.Strategies
{
    public class RangeStrategy : IAttackStrategy
    {
        private readonly Animator _animator;
        private readonly int rangeAttackHash = Animator.StringToHash("Range");

        public RangeStrategy(Animator anim) => _animator = anim;

        public void Attack()
        {
            _animator.SetTrigger(rangeAttackHash);
        }
    }
}