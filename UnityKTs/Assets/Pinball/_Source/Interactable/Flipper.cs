using System.Collections;
using Pinball.Player;
using UnityEngine;

namespace Pinball.Interactable
{
    public class Flipper : MonoBehaviour
    {
        [SerializeField] private Rigidbody flipperRb;
        [SerializeField] private Transform forcePivot;
        [SerializeField] private Collider bouncerCollider;
        [SerializeField] private float forcePower;
        [SerializeField] private float flipperCooldown;
        [SerializeField] private bool rightFlipper;
        
        private PlayerInput _input;
        private bool _canForce = true;

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        public void Construct(PlayerInput input) => _input = input;

        private void OnFlipperInput()
        {
            if(!_canForce)
                return;

            bouncerCollider.isTrigger = true;
            flipperRb.linearVelocity = Vector3.zero;
            flipperRb.AddForce(forcePivot.forward * forcePower, ForceMode.Impulse);
            _canForce = false;

            StartCoroutine(FlipperCooldownCoroutine());
        }
        
        private void Bind()
        {
            if (rightFlipper)
                _input.OnRightFlipperInput += OnFlipperInput;
            else
                _input.OnLeftFlipperInput += OnFlipperInput;
        }

        private void Expose()
        {
            if (rightFlipper)
                _input.OnRightFlipperInput -= OnFlipperInput;
            else
                _input.OnLeftFlipperInput -= OnFlipperInput;
        }

        private IEnumerator FlipperCooldownCoroutine()
        {
            yield return new WaitForSeconds(flipperCooldown);

            bouncerCollider.isTrigger = false;
            _canForce = true;
        }
    }
}