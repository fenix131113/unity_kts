using UnityEngine;

namespace ISP_GWENT.Cards.SO
{
    public abstract class CardSO : ScriptableObject
    {
        [field: SerializeField] public string CardName { get; protected set; }
        [field: SerializeField] public string Description { get; protected set; }
        [field: SerializeField] public Sprite Icon { get; protected set; }
    }
}