using System;
using UnityEngine;

namespace OCP._Source.Attack
{
    public class AttackPerformer : MonoBehaviour
    {
        private IAttackStrategy _currentStrategy;
        public event Action<IAttackStrategy> OnStrategyChanged;
        public event Action OnPlayerAttack;

        public void SetStrategy(IAttackStrategy attackStrategy)
        {
            _currentStrategy = attackStrategy;
            OnStrategyChanged?.Invoke(_currentStrategy);
        }

        public void Attack()
        {
            _currentStrategy.Attack();
            OnPlayerAttack?.Invoke();
        }
    }
}
