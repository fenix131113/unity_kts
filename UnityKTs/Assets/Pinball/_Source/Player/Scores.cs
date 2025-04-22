using System;

namespace Pinball.Player
{
    public class Scores
    {
        public int ScoresCount { get; private set; }

        public event Action OnScoresChanged;
        
        public void AddScore(int scores)
        {
            ScoresCount += scores;
            OnScoresChanged?.Invoke();
        }
    }
}