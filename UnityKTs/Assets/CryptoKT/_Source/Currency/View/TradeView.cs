using Currency.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Currency.View
{
    public class TradeView : MonoBehaviour
    {
        [SerializeField] private Image currencyImage;
        [SerializeField] private TMP_Text currencyNameLabel;
        [SerializeField] private TMP_Text currencyCostLabel;
        [SerializeField] private Button buyButton;
        [SerializeField] private Button sellButton;

        private CurrencyType _currencyType;
        private Wallet _wallet;
        private Agregator _agregator;
        
        public void Construct(Wallet wallet, Agregator agregator, CurrencyType currencyType)
        {
            _wallet = wallet;
            _agregator = agregator;
            _currencyType = currencyType;
        }

        private void Start()
        {
            Bind();
            currencyImage.sprite = _wallet.GetCurrencyData(_currencyType).Icon;
            Redraw();
        }

        private void OnDestroy() => Expose();

        private void Redraw()
        {
            currencyNameLabel.text = _wallet.GetCurrencyData(_currencyType).CurrencyName;
            currencyCostLabel.text = $"${_agregator.GetCost(_currencyType)}";
        }

        private void OnBuyButtonClicked()
        {
            var balance = _wallet.Balance;
            var cost = _agregator.GetCost(_currencyType);

            if (balance < cost)
            {
                Notifications.Instance.SendNotification("Can't buy this currency. Need more money!");
                return;
            }
            
            _wallet.ChangeCurrency(CurrencyType.SCHIRSHI, -cost);
            _wallet.ChangeCurrency(_currencyType, 1);
        }
        
        private void OnSellButtonClicked()
        {
            if (_wallet.GetCurrencyValue(_currencyType) <= 0)
            {
                Notifications.Instance.SendNotification("Can't sell this currency. Need more currency!");
                return;
            }
            
            _wallet.ChangeCurrency(CurrencyType.SCHIRSHI, _agregator.GetCost(_currencyType));
            _wallet.ChangeCurrency(_currencyType, -1);
        }

        private void Bind()
        {
            buyButton.onClick.AddListener(OnBuyButtonClicked);
            sellButton.onClick.AddListener(OnSellButtonClicked);
            _agregator.OnCostUpdated += Redraw;
        }

        private void Expose()
        {
            buyButton.onClick.RemoveListener(OnBuyButtonClicked);
            sellButton.onClick.RemoveListener(OnSellButtonClicked);
            _agregator.OnCostUpdated -= Redraw;
        }
    }
}