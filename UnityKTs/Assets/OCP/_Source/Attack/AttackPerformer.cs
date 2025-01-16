using UnityEngine;

namespace OCP._Source.Attack
{
    public class AttackPerformer : MonoBehaviour
    {
        private IAttackStrategy _currentStrategy;

        public void SetStrategy(IAttackStrategy attackStrategy) => _currentStrategy = attackStrategy;

        public void Attack() => _currentStrategy.Attack();
    }
}
