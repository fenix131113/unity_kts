using System.IO;
using UnityEngine;
using Zenject;

namespace ServiceLocator.SaveSystem
{
    public class JsonSave : ISaver
    {
        private readonly Score _score;

        [Inject]
        public JsonSave(Score score) => _score = score;

        public void SaveScore(string path = null)
        {
            if (path != null)
                File.WriteAllText(path, JsonUtility.ToJson(_score.Count));
        }
    }
}