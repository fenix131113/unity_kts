using System.Collections.Generic;
using Currency;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private List<CurrencySO> currencies = new();

        public override void InstallBindings()
        {
            Container.BindInstance(currencies).AsSingle().NonLazy();
            Container.Bind<Wallet>().AsSingle().NonLazy();
            Container.Bind<Agregator>().FromComponentsInHierarchy().AsSingle().NonLazy();
        }
    }
}