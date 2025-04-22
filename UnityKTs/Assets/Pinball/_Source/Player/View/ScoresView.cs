using TMPro;
using UnityEngine;

namespace Pinball.Player.View
{
    public class ScoresView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoresLabel;
        
        private Scores _scores;

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        public void Construct(Scores scores) => _scores = scores;
        
        private void Redraw() => scoresLabel.text = _scores.ScoresCount.ToString();

        private void Bind() => _scores.OnScoresChanged += Redraw;

        private void Expose() => _scores.OnScoresChanged -= Redraw;
    }
}