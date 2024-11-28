using StateMachineKT.GameStates;
using StateMachineKT.Player;
using StateMachineKT.Player.Data;
using UnityEngine;
using Zenject;

namespace StateMachineKT.Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSettingsSO playerSettings;
        
        public override void InstallBindings()
        {
            BindPlayer();
            BindStateMachine();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>()
                .AsSingle()
                .NonLazy();

            Container.Bind<PlayerSettingsSO>()
                .FromInstance(playerSettings)
                .AsSingle()
                .NonLazy();

            Container.Bind<PlayerAbilities>()
                .FromComponentsInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerStateSwitcher>()
                .AsSingle()
                .NonLazy();
        }

        private void BindStateMachine()
        {
            Container.Bind<PlayerStateMachine>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<StateMachinesLoader>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<GameStatesSwitcher>()
                .AsSingle()
                .NonLazy();
        }
    }
}
