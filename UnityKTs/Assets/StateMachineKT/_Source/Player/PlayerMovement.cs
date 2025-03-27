using StateMachineKT.Player.Data;
using UnityEngine;
using Zenject;

namespace StateMachineKT.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        
        private PlayerInput _playerInput;
        private PlayerSettingsSO _playerSettings;
        
        [Inject]
        private void Construct(PlayerInput playerInput, PlayerSettingsSO playerSettings)
        {
            _playerInput = playerInput;
            _playerSettings = playerSettings;
        }

        private void Start()
        {
            Bind();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy() => Expose();

        private void Move(Vector2 input)
        {
            _rb.linearVelocity = input.normalized * _playerSettings.MoveSpeed;
        }
        
        private void Bind()
        {
            _playerInput.OnMove += Move;
        }

        private void Expose()
        {
            _playerInput.OnMove -= Move;
        }
    }
}