using UnityEngine.UIElements;
using Zenject;

namespace ServiceLocator.Ui
{
    public class MenuUiState : IUiState
    {
        private readonly VisualElement _menuPanel;
        private readonly FadeService _fadeService;
        private readonly SoundPlayer _soundPlayer;

        [Inject]
        public MenuUiState(UIDocument menuUi, FadeService fadeService, SoundPlayer soundPlayer)
        {
            _menuPanel = menuUi.rootVisualElement.Q<VisualElement>("Menu");
            _fadeService = fadeService;
            _soundPlayer = soundPlayer;
        }

        public void Enter()
        {
            _menuPanel.visible = true;
            _menuPanel.style.opacity = 0f;

            _fadeService.FadeOut(_menuPanel, 0.5f);
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _fadeService.FadeIn(_menuPanel, 0.5f, () => _menuPanel.visible = false);
            _soundPlayer.PlayOpenSound();
        }
    }
}