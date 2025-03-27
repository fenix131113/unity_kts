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
        private UiSwitcher _uiSwitcher;

        public void Init(UiSwitcher uiSwitcher) => _uiSwitcher = uiSwitcher;

        private void Start()
        {
            _openButton = menu.rootVisualElement.Q<Button>("OpenButton");
            _closeButton = menu.rootVisualElement.Q<Button>("MenuCloseButton");
            
            Bind();
        }

        private void OnDestroy() => Expose();

        private void OnOpenButtonMenuClicked() => _uiSwitcher.Switch<MenuUiState>();

        private void OnCloseButtonMenuClicked() => _uiSwitcher.Switch<MainScreenUiState>();

        private void Bind()
        {
            _openButton.clicked += OnOpenButtonMenuClicked; 
            _closeButton.clicked += OnCloseButtonMenuClicked; 
        }

        private void Expose()
        {
            _openButton.clicked -= OnOpenButtonMenuClicked;
            _closeButton.clicked -= OnCloseButtonMenuClicked;
        }
    }
}
