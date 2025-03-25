using System.Collections.Generic;
using ISP_GWENT.Cards;
using ISP_GWENT.Cards.SO;

namespace ISP_GWENT
{
    public class ObjectPool
    {
        private readonly List<CardSO> _cards = new();

        public void Push(CardSO card) => _cards.Add(card);
    }
}