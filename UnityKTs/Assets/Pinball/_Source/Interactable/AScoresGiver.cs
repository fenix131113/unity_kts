using Pinball.Player;
using UnityEngine;

namespace Pinball.Interactable
{
    public abstract class AScoresGiver : MonoBehaviour
    {
        [SerializeField] private int scores;

        private Scores _score;

        public void InitScores(Scores score) => _score = score;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (scores > 0)
                _score.AddScore(scores);
        }
    }
}