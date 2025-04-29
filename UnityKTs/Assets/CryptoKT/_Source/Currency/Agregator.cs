using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Currency.Data;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Currency
{
    public class Agregator : MonoBehaviour
    {
        private readonly Dictionary<CurrencyType, int> _currenciesCosts = new();
        
        private Wallet _wallet;

        public event Action OnCostUpdated;
        
        [Inject]
        private void Construct(Wallet wallet) => _wallet = wallet;

        private void Start()
        {
            foreach (var type in Enum.GetValues(typeof(CurrencyType)).Cast<CurrencyType>().Except(new [] {CurrencyType.SCHIRSHI}))
            {
                var data = _wallet.GetCurrencyData(type);
                _currenciesCosts.Add(type, (data.MinCost + data.MaxCost) / 2);
                StartCoroutine(ChangeCostCoroutine(data.UpdateFrequency, type));
            }
        }

        public int GetCost(CurrencyType currencyType) => _currenciesCosts[currencyType];

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private IEnumerator ChangeCostCoroutine(float time, CurrencyType currencyType)
        {
            yield return new WaitForSeconds(time);
            
            var data = _wallet.GetCurrencyData(currencyType);
            var rndCost = Random.Range(data.MinCost, data.MaxCost);
            var deltaCost = rndCost - _currenciesCosts[currencyType];
            _currenciesCosts[currencyType] += (int)(deltaCost * data.ChangeRatio);
            _currenciesCosts[currencyType] = Mathf.Clamp(_currenciesCosts[currencyType], data.MinCost, data.MaxCost);
            
            OnCostUpdated?.Invoke();
            
            StartCoroutine(ChangeCostCoroutine(time, currencyType));
        }
    }
}