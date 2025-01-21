using UnityEngine;

namespace OCP._Source.Enemy.Enemies
{
    public class FirstEnemy : AEnemy
    {
        private static readonly int _attackKey = Animator.StringToHash("FirstAttack");
        
        public override void OnSpawn()
        {
            Attack();
        }

        public override void Attack()
        {
            EnemyAnimator.SetTrigger(_attackKey);
        }
    }
}