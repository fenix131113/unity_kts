using Pinball.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pinball.Core
{
    public class GameRestarter : MonoBehaviour
    {
        private PlayerInput _input;

        public void Construct(PlayerInput input) => _input = input;

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void Bind() => _input.OnRestartInput += RestartGame;

        private void Expose() => _input.OnRestartInput -= RestartGame;
    }
}