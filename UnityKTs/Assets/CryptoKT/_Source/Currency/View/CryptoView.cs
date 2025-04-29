using Currency.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Currency.View
{
    public class CryptoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text currencyNameLabel;
        [SerializeField] private TMP_Text currencyValueLabel;
        [SerializeField] private Image currencyImage;
        [SerializeField] private CurrencyType type;

        private Wallet _wallet;

        public void Construct(Wallet wallet, CurrencyType currencyType)
        {
            _wallet = wallet;
            type = currencyType;
        }

        private void Start()
        {
            currencyNameLabel.text = _wallet.GetCurrencyData(type).CurrencyName;
            Redraw();
            Bind();
        }

        private void OnDestroy() => Expose();

        private void Redraw()
        {
            currencyValueLabel.text = _wallet.GetCurrencyValue(type).ToString();

            if (currencyImage)
                currencyImage.sprite = _wallet.GetCurrencyData(type).Icon;
        }

        private void Bind() => _wallet.OnCurrencyChanged += Redraw;

        private void Expose() => _wallet.OnCurrencyChanged -= Redraw;
    }
}