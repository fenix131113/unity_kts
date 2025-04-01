using ServiceLocator.Menu;
using ServiceLocator.SaveSystem;
using ServiceLocator.Ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace ServiceLocator
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private UIDocument menuUi;
        [SerializeField] private MenuView menuView;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip openPanelSound;
        [SerializeField] private AudioClip closePanelSound;
        
        private Score _score;
        private UiSwitcher _uiSwitcher;
        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            _serviceLocator = new ServiceLocator();
            _serviceLocator.RegisterService(new FadeService());
            _serviceLocator.RegisterService(new SoundPlayer(audioSource, openPanelSound, closePanelSound));
            
            _score = new Score();
            
            _uiSwitcher = new UiSwitcher();
            
            menuView.Init(_uiSwitcher, _score, new PlayerPrefsSaver(_score));
            
            _uiSwitcher.RegisterState(new MainScreenUiState(menuUi));
            _uiSwitcher.RegisterState(new MenuUiState(menuUi, _serviceLocator));
            
            _uiSwitcher.Switch<MainScreenUiState>();
            
        }
    }
}