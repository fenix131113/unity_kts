using Pinball.Core;
using Pinball.Interactable;
using UnityEngine;

namespace Pinball.Player
{
    public class BallThrower : MonoBehaviour
    {
        [SerializeField] private GameObject tubeCloser;
        [SerializeField] private Transform gamePivot;
        [SerializeField] private Rigidbody ballRb;
        [SerializeField] private EndGame endGame;
        [SerializeField] private float minPower;
        [SerializeField] private float maxPower;
        [SerializeField] private float increaseSpeed;

        public float PowerProgress => (_currentForce - minPower) / (maxPower - minPower);
        public bool IsThrown { get; private set; }

        private PlayerInput _input;
        private DeadZone _deadZone;
        private float _currentForce;
        private Vector3 _startBallPosition;

        public void Construct(PlayerInput input, DeadZone deadZone)
        {
            _input = input;
            _deadZone = deadZone;
        }

        private void Start()
        {
            _currentForce = minPower;
            _startBallPosition = ballRb.transform.position;
            Bind();
        }

        private void OnDestroy() => Expose();

        private void OnThrowInput()
        {
            if (IsThrown || endGame.GameOver)
                return;

            _currentForce = Mathf.Clamp(_currentForce + Time.deltaTime * increaseSpeed, minPower, maxPower);
        }

        private void OnThrowUp()
        {
            if (IsThrown || endGame.GameOver)
                return;

            ballRb.AddForce(gamePivot.forward * _currentForce, ForceMode.Impulse);
            IsThrown = true;
            _currentForce = minPower;
        }

        private void OnDeadZoneReached()
        {
            ballRb.linearVelocity = Vector3.zero;
            ballRb.transform.position = _startBallPosition;
            IsThrown = false;
            tubeCloser.SetActive(false);
        }

        private void Bind()
        {
            _input.OnThrowInput += OnThrowInput;
            _input.OnThrowUp += OnThrowUp;
            _deadZone.OnBallReachedDeadZone += OnDeadZoneReached;
        }

        private void Expose()
        {
            _input.OnThrowInput -= OnThrowInput;
            _input.OnThrowUp -= OnThrowUp;
            _deadZone.OnBallReachedDeadZone -= OnDeadZoneReached;
        }
    }
}