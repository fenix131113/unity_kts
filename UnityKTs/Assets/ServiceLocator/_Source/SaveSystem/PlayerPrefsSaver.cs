using UnityEngine;

namespace ServiceLocator.SaveSystem
{
    public class PlayerPrefsSaver : ISaver
    {
        private readonly Score _score;

        public PlayerPrefsSaver(Score score) => _score = score;

        public void SaveScore(string path = null) => PlayerPrefs.SetInt(path ?? "Score", _score.Count);
    }
}