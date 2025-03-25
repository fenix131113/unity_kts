using ISP_GWENT.Cards.Data;
using ISP_GWENT.Cards.SO;
using UnityEngine;

namespace ISP_GWENT.Cards
{
    [CreateAssetMenu(fileName = "Special Card", menuName = "SO/GWENT/Special Card")]
    public class SpecialCardSO : CardSO, ISpecialMoveCard
    {
        [field: SerializeField] private SpecialAbilityType specialType;
        
        public SpecialAbilityType GetSpecialType => specialType;

        public void SpecialMove()
        {
            Debug.Log($"{CardName} use special type {specialType}!");
        }
    }
}