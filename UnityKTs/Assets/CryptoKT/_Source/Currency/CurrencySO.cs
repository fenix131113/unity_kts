using Currency.Data;
using UnityEngine;

namespace Currency
{
    [CreateAssetMenu(fileName = "New Currency", menuName = "Configs/New Currency")]
    public class CurrencySO : ScriptableObject
    {
        [field: SerializeField] public CurrencyType CurrencyType { get; private set; }
        [field: SerializeField] public string CurrencyName { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int MinCost { get; private set; }
        [field: SerializeField] public int MaxCost { get; private set; }

        [field: SerializeField]
        [Range(0f, 1f)]
        public float ChangeRatio { get; private set; }
        [field: SerializeField] public float UpdateFrequency { get; private set; }
    }
}