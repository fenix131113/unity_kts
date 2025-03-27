using UnityEngine;

namespace ISP_GWENT.Cards.SO
{
    [CreateAssetMenu(fileName = "Leader Card", menuName = "SO/GWENT/Leader Card")]
    public class LeaderCardSO : CardSO, ILeaderCard
    {
        public virtual void UseUltimate()
        {
            Debug.Log($"{CardName} use ultimate!");
        }

        public override void Use()
        {
            UseUltimate();
        }
    }
}