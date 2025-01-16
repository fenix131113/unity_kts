using System;
using OCP._Source.Attack.Strategies;
using UnityEngine;

namespace OCP._Source.Attack.View
{
    public class AttackButtonsContainer : MonoBehaviour
    {
        [SerializeField] private AttackTypeButton straightAttackButton;
        [SerializeField] private AttackTypeButton rangeAttackButton;
        [SerializeField] private AttackTypeButton braidAttackButton;
        [SerializeField] private StraightStrategy straightStrategy;
        [SerializeField] private RangeStrategy rangeStrategy;
        [SerializeField] private BraidStrategy braidStrategy;

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
                AttackType.STRAIGHT => straightStrategy,
                AttackType.RANGE => rangeStrategy,
                AttackType.BRAID => braidStrategy,
                _ => throw new NotImplementedException()
            };
            
            _attackPerformer.SetStrategy(strategy);
        }

        private void Bind()
        {
            straightAttackButton.OnButtonClicked += SelectCurrentButton;
            rangeAttackButton.OnButtonClicked += SelectCurrentButton;
            braidAttackButton.OnButtonClicked += SelectCurrentButton;
        }

        private void Expose()
        {
            straightAttackButton.OnButtonClicked -= SelectCurrentButton;
            rangeAttackButton.OnButtonClicked -= SelectCurrentButton;
            braidAttackButton.OnButtonClicked -= SelectCurrentButton;
        }
    }
}