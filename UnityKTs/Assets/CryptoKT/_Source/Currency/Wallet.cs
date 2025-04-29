using System;
using System.Collections.Generic;
using System.Linq;
using Currency.Data;
using Zenject;

namespace Currency
{
    public class Wallet
    {
        private const int START_BALANCE = 25;
        
        public int Balance => GetCurrencyValue(CurrencyType.SCHIRSHI);

        private readonly Dictionary<CurrencyType, int> _currencies = new();

        private readonly List<CurrencySO> _currenciesData;
        
        public event Action OnCurrencyChanged;

        [Inject]
        public Wallet(List<CurrencySO> currenciesData)
        {
            foreach (var type in Enum.GetValues(typeof(CurrencyType)))
                _currencies.Add((CurrencyType)type, 0);

            _currenciesData = currenciesData;
            _currencies[CurrencyType.SCHIRSHI] = START_BALANCE;
        }
        
        public int GetCurrencyValue(CurrencyType currencyType) => _currencies[currencyType];

        public CurrencySO GetCurrencyData(CurrencyType currencyType) =>
            _currenciesData.First(x => x.CurrencyType == currencyType);

        public void ChangeCurrency(CurrencyType currencyType, int amount)
        {
            _currencies[currencyType] += amount;
            OnCurrencyChanged?.Invoke();
        }
    }
}