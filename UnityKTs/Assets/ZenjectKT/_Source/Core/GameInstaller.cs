using UnityEngine;
using Zenject;
using ZenjectKT.Player;

namespace ZenjectKT.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Bullet bulletPrefab;

        public override void InstallBindings()
        {
            Container.Bind<TargetsContainer>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle().NonLazy();

            Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(bulletPrefab);
            Container.Bind<ObjectPool<Bullet>>().AsSingle().NonLazy();
        }
    }
}