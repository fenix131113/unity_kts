using UnityEngine;
using Zenject;
using ZenjectKT.Core;

namespace ZenjectKT.Player
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;

        private ObjectPool<Bullet> _pool;
        private PlayerInput _playerInput;
        private Bullet.Factory _bulletFactory;
        private TargetsContainer _targetsContainer;

        [Inject]
        private void Construct(PlayerInput playerInput, Bullet.Factory bulletFactory, ObjectPool<Bullet> pool,
            TargetsContainer targetsContainer)
        {
            _pool = pool;
            _playerInput = playerInput;
            _bulletFactory = bulletFactory;
            _targetsContainer = targetsContainer;
        }

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void OnShoot()
        {
            var target = _targetsContainer.GetScreenTarget();

            var created = _pool.Pop();

            if (!created)
                created = _bulletFactory.Create();

            created.transform.rotation = 
                target ? Quaternion.LookRotation((target.position - transform.position).normalized) 
                    : shootPoint.parent.rotation;

            created.transform.position = shootPoint.position;
            created.gameObject.SetActive(true);
        }

        private void Bind() => _playerInput.OnShoot += OnShoot;

        private void Expose() => _playerInput.OnShoot -= OnShoot;
    }
}