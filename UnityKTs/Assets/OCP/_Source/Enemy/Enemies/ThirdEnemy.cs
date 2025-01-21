using OCP._Source.Attack;
using UnityEngine;

namespace OCP._Source.Enemy.Enemies
{
    public class ThirdEnemy : AEnemy
    {
        [SerializeField] private AttackPerformer attackPerformer;
        
        private static readonly int _thirdAttack = Animator.StringToHash("ThirdAttack");

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        public override void Attack() => EnemyAnimator.SetTrigger(_thirdAttack);

        private void Bind() => attackPerformer.OnPlayerAttack += Attack;

        private void Expose() => attackPerformer.OnPlayerAttack -= Attack;
    }
}