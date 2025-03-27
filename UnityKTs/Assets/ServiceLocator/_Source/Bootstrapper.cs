using ServiceLocator.Menu;
using ServiceLocator.Ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace ServiceLocator
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private UIDocument menuUi;
        [SerializeField] private MenuView menuView;
        
        private UiSwitcher _uiSwitcher;

        private void Awake()
        {
            _uiSwitcher = new UiSwitcher();
            
            menuView.Init(_uiSwitcher);
            
            _uiSwitcher.RegisterState(new MainScreenUiState(menuUi));
            _uiSwitcher.RegisterState(new MenuUiState(menuUi));
            
            _uiSwitcher.Switch<MainScreenUiState>();
        }
    }
}