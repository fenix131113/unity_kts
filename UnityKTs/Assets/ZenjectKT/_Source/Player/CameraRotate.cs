using UnityEngine;
using Zenject;

namespace ZenjectKT.Player
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 1f;
        [SerializeField] private float maxAngle = 80f;

        private PlayerInput _playerInput;
        private float _pitch;
        private float _yaw;

        [Inject]
        private void Construct(PlayerInput playerInput) => _playerInput = playerInput;

        private void Start()
        {
            Bind();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDestroy() => Expose();

        private void OnMouseMove(Vector2 velocity)
        {
            _yaw += velocity.x * sensitivity;
            _pitch -= velocity.y * sensitivity;

            _pitch = Mathf.Clamp(_pitch, -maxAngle, maxAngle);

            transform.rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        }

        private void Bind() => _playerInput.OnMouseMove += OnMouseMove;

        private void Expose() => _playerInput.OnMouseMove -= OnMouseMove;
    }
}