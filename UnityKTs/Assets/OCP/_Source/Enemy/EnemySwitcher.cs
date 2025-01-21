using System;
using System.Collections.Generic;
using OCP._Source.Attack;
using OCP._Source.Attack.Strategies;
using UnityEngine;

namespace OCP._Source.Enemy
{
    public class EnemySwitcher : MonoBehaviour
    {
        [SerializeField] private List<AEnemy> enemies;

        private AEnemy _currentEnemy;
        private AttackPerformer _attackPerformer;

        public void Init(AttackPerformer attackPerformer)
        {
            _attackPerformer = attackPerformer;
            Bind();
        }

        private void OnDestroy() => Expose();

        private void Switch(IAttackStrategy strategy)
        {
            var index = strategy switch
            {
                StraightStrategy => 0,
                RangeStrategy => 1,
                BraidStrategy => 2,
                _ => throw new ArgumentOutOfRangeException(nameof(strategy))
            };


            _currentEnemy?.gameObject.SetActive(false);
            _currentEnemy = enemies[index];
            _currentEnemy.gameObject.SetActive(true);
            _currentEnemy.OnSpawn();
        }

        private void Bind() => _attackPerformer.OnStrategyChanged += Switch;

        private void Expose() => _attackPerformer.OnStrategyChanged -= Switch;
    }
}