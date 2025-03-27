using UnityEngine.UIElements;

namespace ServiceLocator.Ui
{
    public class MainScreenUiState : IUiState
    {
        private readonly Button _openMenuButton;
        
        public MainScreenUiState(UIDocument menuUi)
        {
            _openMenuButton = menuUi.rootVisualElement.Q<Button>("OpenButton");
        }

        public void Enter() => _openMenuButton.SetEnabled(true);

        public void Exit() => _openMenuButton.SetEnabled(false);
    }
}