using UnityEngine;
using UnityEngine.UI;

namespace Pinball.Core.View
{
    public class EndGameView : MonoBehaviour
    {
        [SerializeField] private EndGame endGame;
        [SerializeField] private GameRestarter gameRestarter;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Button restartButton;
        
        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void ShowEndGamePanel() => endGamePanel.SetActive(true);

        private void OnRestartButtonClicked() => gameRestarter.RestartGame();

        private void Bind()
        {
            endGame.OnGameEnded += ShowEndGamePanel;
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void Expose()
        {
            endGame.OnGameEnded -= ShowEndGamePanel;
            restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }
    }
}