using System;
using System.Collections.Generic;
using OCP._Source.Attack.Strategies;
using UnityEngine;

namespace OCP._Source.Attack.View
{
    public class AttackButtonsContainer : MonoBehaviour
    {
        [SerializeField] private List<AttackTypeButton> buttons = new();
        [SerializeField] private Animator attackAnimator;

        private AttackTypeButton _currentButton;
        private AttackPerformer _attackPerformer;

        public void Init(AttackPerformer attackPerformer) => _attackPerformer = attackPerformer;

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void SelectCurrentButton(AttackType attackType, AttackTypeButton currentButton)
        {
            _currentButton?.DeactivateVisual();
            _currentButton = currentButton;
            _currentButton.ActivateVisual();

            IAttackStrategy strategy = attackType switch
            {
                AttackType.STRAIGHT => new StraightStrategy(attackAnimator),
                AttackType.RANGE => new RangeStrategy(attackAnimator),
                AttackType.BRAID => new BraidStrategy(attackAnimator),
                _ => throw new NotImplementedException()
            };
            
            _attackPerformer.SetStrategy(strategy);
        }

        private void Bind()
        {
            foreach (var attackTypeButton in buttons)
                attackTypeButton.OnButtonClicked += SelectCurrentButton;
        }

        private void Expose()
        {
            foreach (var attackTypeButton in buttons)
                attackTypeButton.OnButtonClicked -= SelectCurrentButton;
        }
    }
}