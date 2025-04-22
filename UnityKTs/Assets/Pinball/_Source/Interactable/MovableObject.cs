using DG.Tweening;
using UnityEngine;

namespace Pinball.Interactable
{
    public class MovableObject : MonoBehaviour
    {
        [SerializeField] private bool isMoving;
        [SerializeField] private Transform target;
        [SerializeField] private float moveTime;
        [SerializeField] private bool isRotating;
        [SerializeField] private Vector3 rotateVector;

        private bool _targetReached;
        private Vector3 _startPosition;
        private Tween _moveTween;

        private void Start() => _startPosition = transform.position;

        private void Update()
        {
            if (isMoving && (_moveTween == null ||  !_moveTween.IsActive()))
            {
                _moveTween = transform.DOMove(_targetReached ? _startPosition : target.position, moveTime).SetEase(Ease.Linear);
                _moveTween.onComplete += () => _targetReached = !_targetReached;
            }

            if (isRotating)
                transform.Rotate(rotateVector * Time.deltaTime);
        }
    }
}