using Pinball.Core;
using Pinball.Interactable;
using TMPro;
using UnityEngine;

namespace Pinball.Player.View
{
    public class BallsCounter : MonoBehaviour
    {
        private const string COUNTER_PREFIX = "Шариков: ";
        
        [SerializeField] private TMP_Text ballsCounterLabel;
        [SerializeField] private EndGame endGame;
        [SerializeField] private DeadZone deadZone;
        
        private void Start()
        {
            Bind();
            Redraw();
        }

        private void OnDestroy() => Expose();

        private void Redraw() => ballsCounterLabel.text = COUNTER_PREFIX + endGame.CurrentBallsCount;

        private void Bind() => deadZone.OnBallReachedDeadZone += Redraw;

        private void Expose() => deadZone.OnBallReachedDeadZone -= Redraw;
    }
}