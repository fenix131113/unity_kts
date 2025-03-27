using ISP_GWENT.Cards.Data;
using UnityEngine;

namespace ISP_GWENT.Cards.SO
{
    [CreateAssetMenu(fileName = "Line Position Cards", menuName = "SO/GWENT/Line Position Card")]
    public class LinePositionCardSO : CardSO, ILinePositionCard, IPowerScoresCard, IRareCard
    {
        [field: SerializeField] protected LinePosition linePosition;
        [field: SerializeField] protected int powerScores;
        
        public int PowerScore => powerScores;
        
        LinePosition ILinePositionCard.LinePosition => linePosition;
        
        public void UsePowerScores()
        {
            Debug.Log($"Used {powerScores} power scores!");
        }

        public override void Use()
        {
            UsePowerScores();
        }
    }
}