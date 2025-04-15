using System.Collections;
using UnityEngine;
using Zenject;
using ZenjectKT.Core;

namespace ZenjectKT
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;

        private ObjectPool<Bullet> _pool;

        [Inject]
        private void Construct(ObjectPool<Bullet> pool) => _pool = pool;

        private void Start() => StartCoroutine(ReturnCoroutine());

        private void OnEnable() => StartCoroutine(ReturnCoroutine());

        private void Update() => transform.position += transform.forward * (Time.deltaTime * speed);

        private void OnTriggerEnter(Collider other) => ReturnToPool();

        private void ReturnToPool()
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
            _pool.Push(this);
        }

        private IEnumerator ReturnCoroutine()
        {
            yield return new WaitForSeconds(lifetime);

            ReturnToPool();
        }

        public class Factory : PlaceholderFactory<Bullet>
        {
        }
    }
}