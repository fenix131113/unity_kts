using UnityEngine.UIElements;

namespace ServiceLocator.Ui
{
    public class MenuUiState : IUiState
    {
        private readonly VisualElement _menuPanel;
        private readonly ServiceLocator _serviceLocator;
        
        public MenuUiState(UIDocument menuUi, ServiceLocator serviceLocator)
        {
            _menuPanel = menuUi.rootVisualElement.Q<VisualElement>("Menu");
            _serviceLocator = serviceLocator;
        }

        public void Enter()
        {
            _menuPanel.visible = true;
            _menuPanel.style.opacity = 0f;

            if(_serviceLocator.GetService(out FadeService fade))
                fade.FadeOut(_menuPanel, 0.5f);
            if(_serviceLocator.GetService(out SoundPlayer source))
                source.PlayOpenSound();
        }

        public void Exit()
        {
            if(_serviceLocator.GetService(out FadeService fade))
                fade.FadeIn(_menuPanel, 0.5f, () => _menuPanel.visible = false);
            if(_serviceLocator.GetService(out SoundPlayer source))
                source.PlayOpenSound();
        }
    }
}