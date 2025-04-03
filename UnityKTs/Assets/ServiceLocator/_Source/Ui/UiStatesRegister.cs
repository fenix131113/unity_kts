using UnityEngine.UIElements;
using Zenject;

namespace ServiceLocator.Ui
{
    public class UiStatesRegister : IInitializable

    {
        private readonly UiSwitcher _switcher;
        private readonly UIDocument _menuUi;
        private readonly FadeService _fadeService;
        private readonly SoundPlayer _soundPlayer;

        [Inject]
        public UiStatesRegister(UiSwitcher switcher, UIDocument menuUi, FadeService fadeService,
            SoundPlayer soundPlayer)
        {
            _switcher = switcher;
            _menuUi = menuUi;
            _fadeService = fadeService;
            _soundPlayer = soundPlayer;
        }

        public void Initialize()
        {
            RegisterStates();
        }

        private void RegisterStates()
        {
            _switcher.RegisterState(new MainScreenUiState(_menuUi));
            _switcher.RegisterState(new MenuUiState(_menuUi, _fadeService, _soundPlayer));

            _switcher.Switch<MainScreenUiState>();
        }
    }
}