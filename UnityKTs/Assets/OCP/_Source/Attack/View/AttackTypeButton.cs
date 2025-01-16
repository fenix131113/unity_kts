using System;
using UnityEngine;
using UnityEngine.UI;

namespace OCP._Source.Attack.View
{
    public class AttackTypeButton : MonoBehaviour
    {
        [SerializeField] private AttackType attackType;
        [SerializeField] private Image buttonImage;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color selectedColor;
        [SerializeField] private bool useOnStart;
        
        public event Action<AttackType, AttackTypeButton> OnButtonClicked;

        private void Awake() => GetComponent<Button>().onClick.AddListener(InvokeButtonClicked);

        private void Start()
        {
            if(useOnStart)
                InvokeButtonClicked();
        }

        private void InvokeButtonClicked() => OnButtonClicked?.Invoke(attackType, this);

        public void ActivateVisual() => buttonImage.color = selectedColor;

        public void DeactivateVisual() => buttonImage.color = defaultColor;
    }
}