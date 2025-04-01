using ServiceLocator.SaveSystem;
using ServiceLocator.Ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace ServiceLocator.Menu
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private UIDocument menu;

        private Button _openButton;
        private Button _closeButton;
        private Button _collectButton;
        private UiSwitcher _uiSwitcher;
        private Score _score;
        private Label _counterLabel;
        private ISaver _saver;

        public void Init(UiSwitcher uiSwitcher, Score score, ISaver saver)
        {
            _uiSwitcher = uiSwitcher;
            _score = score;
            _saver = saver;
        }

        private void Start()
        {
            _openButton = menu.rootVisualElement.Q<Button>("OpenButton");
            _closeButton = menu.rootVisualElement.Q<Button>("MenuCloseButton");
            _collectButton = menu.rootVisualElement.Q<Button>("CollectButton");
            _counterLabel = menu.rootVisualElement.Q<Label>("CounterLabel");

            Bind();
        }

        private void OnDestroy() => Expose();

        private void OnOpenButtonMenuClicked() => _uiSwitcher.Switch<MenuUiState>();

        private void OnCloseButtonMenuClicked()
        {
            _uiSwitcher.Switch<MainScreenUiState>();
            _saver.SaveScore();
        }

        private void OnCollectButtonClicked()
        {
            _score.Increase();
            _counterLabel.text = _score.Count.ToString();
        }

        private void Bind()
        {
            _openButton.clicked += OnOpenButtonMenuClicked;
            _closeButton.clicked += OnCloseButtonMenuClicked;
            _collectButton.clicked += OnCollectButtonClicked;
        }

        private void Expose()
        {
            _openButton.clicked -= OnOpenButtonMenuClicked;
            _closeButton.clicked -= OnCloseButtonMenuClicked;
            _collectButton.clicked -= OnCollectButtonClicked;
        }
    }
}