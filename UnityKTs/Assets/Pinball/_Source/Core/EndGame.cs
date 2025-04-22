using System;
using Pinball.Interactable;
using UnityEngine;

namespace Pinball.Core
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private int startBallsCount;
        [SerializeField] private DeadZone deadZone;

        public bool GameOver { get; private set; }
        public int CurrentBallsCount { get; private set; }

        public event Action OnGameEnded;

        private void Awake()
        {
            CurrentBallsCount = startBallsCount;
            Bind();
        }

        private void OnDestroy() => Expose();

        private void OnBallReachedDeadZone()
        {
            CurrentBallsCount--;

            if (CurrentBallsCount != 0)
                return;
            
            GameOver = true;
            OnGameEnded?.Invoke();
        }

        private void Bind() => deadZone.OnBallReachedDeadZone += OnBallReachedDeadZone;

        private void Expose() => deadZone.OnBallReachedDeadZone -= OnBallReachedDeadZone;
    }
}