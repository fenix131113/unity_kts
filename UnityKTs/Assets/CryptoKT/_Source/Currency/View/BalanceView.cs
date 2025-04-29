using TMPro;
using UnityEngine;
using Zenject;

namespace Currency.View
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text balanceLabel;
        
        private Wallet _wallet;
        
        [Inject]
        private void Construct(Wallet wallet) => _wallet = wallet;

        private void Start()
        {
            Bind();
            Redraw();
        }

        private void OnDestroy() => Expose();

        private void Redraw() => balanceLabel.text = $"Balance: {_wallet.Balance}$";

        private void Bind() => _wallet.OnCurrencyChanged += Redraw;

        private void Expose() => _wallet.OnCurrencyChanged -= Redraw;
    }
}