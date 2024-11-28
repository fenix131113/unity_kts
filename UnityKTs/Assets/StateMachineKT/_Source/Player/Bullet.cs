using UnityEngine;

namespace StateMachineKT.Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Start() => Destroy(gameObject, 4f);

        private void Update() => transform.position += transform.up * (Time.deltaTime * speed);
    }
}