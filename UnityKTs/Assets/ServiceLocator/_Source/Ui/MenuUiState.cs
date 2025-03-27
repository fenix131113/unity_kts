using UnityEngine.UIElements;

namespace ServiceLocator.Ui
{
    public class MenuUiState : IUiState
    {
        private readonly VisualElement _menuPanel;
        
        public MenuUiState(UIDocument menuUi)
        {
            _menuPanel = menuUi.rootVisualElement.Q<VisualElement>("Menu");
        }

        public void Enter() => _menuPanel.visible = true;

        public void Exit() => _menuPanel.visible = false;
    }
}