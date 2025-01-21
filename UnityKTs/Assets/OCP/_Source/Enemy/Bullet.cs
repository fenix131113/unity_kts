using UnityEngine;

namespace OCP._Source.Enemy
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] private float lifeTime;

        private void Start() => Destroy(gameObject, lifeTime);

        private void Update() => transform.position += -transform.up * (speed * Time.deltaTime);
    }
}