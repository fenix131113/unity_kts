using ISP_GWENT.Cards.Data;
using UnityEngine;

namespace ISP_GWENT.Cards.SO
{
    [CreateAssetMenu(fileName = "Special Line Position Cards", menuName = "SO/GWENT/Special Line Position Card")]
    public class SpecialLinePositionCard : LinePositionCardSO, ISpecialMoveCard
    {
        [field: SerializeField] protected SpecialAbilityType specialAbilityType;
        public SpecialAbilityType GetSpecialType => specialAbilityType;
        
        public void SpecialMove()
        {
            Debug.Log($"{CardName} used special ability: {specialAbilityType}");
        }
    }
}