using System.Collections.Generic;
using ISP_GWENT.Cards;
using ISP_GWENT.Cards.SO;
using UnityEngine;

namespace ISP_GWENT
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<CardSO> cards;
        
        private ObjectPool _objectPool = new();

        public void Start()
        {
            foreach (var card in cards)
            {
                _objectPool.Push(card);

                var print = "";
                
                print += "Имя: " + card.CardName + "; ";
                print += "Описание: " + card.Description + "; ";
                
                if(card is ILinePositionCard linePositionCard)
                    print += $"Позиция: {linePositionCard.LinePosition}; ";
                if(card is IPowerScoresCard powerScoresCard)
                    print += $"Очки силы: {powerScoresCard.PowerScore}; ";
                if(card is ILeaderCard)
                    print += "Карта лидера; ";
                if(card is IRareCard)
                    print += "Редкая карта; ";
                if(card is ISpecialMoveCard specialAbilityCard)
                    print += $"Карта со специальной способностью: {specialAbilityCard.GetSpecialType}; ";
                if(card is IWeatherCard)
                    print += "Карта погоды;";
                
                Debug.Log(print);
            }
        }
    }
}
