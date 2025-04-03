using ServiceLocator.Menu;
using ServiceLocator.SaveSystem;
using ServiceLocator.Ui;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace ServiceLocator.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private UIDocument menuUi;
        [SerializeField] private MenuView menuView;
        
        public override void InstallBindings()
        {
            Container.Bind<UIDocument>().FromInstance(menuUi).AsSingle().NonLazy();
            Container.Bind<MenuView>().FromInstance(menuView).AsSingle();
            
            Container.Bind<Score>().AsSingle();
            Container.BindInterfacesTo<PlayerPrefsSaver>().AsSingle();

            Container.BindInterfacesTo<UiStatesRegister>().AsSingle().NonLazy();
            Container.Bind<UiSwitcher>().AsSingle();
            Container.Bind<FadeService>().AsSingle().NonLazy();
            Container.Bind<SoundPlayer>().AsSingle().NonLazy();
            Container.Bind<SoundPlayerSetup>().FromComponentInHierarchy().AsSingle();
        }
    }
}