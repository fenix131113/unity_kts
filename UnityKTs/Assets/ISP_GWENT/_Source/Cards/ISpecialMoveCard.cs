using ISP_GWENT.Cards.Data;

namespace ISP_GWENT.Cards
{
    public interface ISpecialMoveCard
    {
        public SpecialAbilityType GetSpecialType { get; }

        public void SpecialMove();
    }
}