using System;
using System.Linq;
using Currency.Data;
using UnityEngine;
using Zenject;

namespace Currency.View
{
    public class UiLoader : MonoBehaviour
    {
        [SerializeField] private CryptoView cryptoCounterPrefab;
        [SerializeField] private Transform countersSpawnParent;
        [SerializeField] private TradeView tradeViewPrefab;
        [SerializeField] private Transform tradesViewSpawnParent;

        private Wallet _wallet;
        private Agregator _agregator;

        [Inject]
        private void Construct(Wallet wallet, Agregator agregator)
        {
            _wallet = wallet;
            _agregator = agregator;
        }

        private void Start() => Spawn();

        private void Spawn()
        {
            foreach (var type in Enum.GetValues(typeof(CurrencyType)).Cast<CurrencyType>()
                         .Except(new[] { CurrencyType.SCHIRSHI }))
            {
                Instantiate(cryptoCounterPrefab, countersSpawnParent).Construct(_wallet, type);
                Instantiate(tradeViewPrefab, tradesViewSpawnParent).Construct(_wallet, _agregator, type);
            }
        }
    }
}