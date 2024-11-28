using StateMachineKT.GameStates.States;
using StateMachineKT.Player;
using Zenject;

namespace StateMachineKT.GameStates
{
    public class GameStatesSwitcher : IInitializable
    {
        private readonly PlayerInput _playerInput;
        private readonly GameStateMachine _stateMachine;

        [Inject]
        public GameStatesSwitcher(PlayerInput playerInput, GameStateMachine gameStateMachine)
        {
            _playerInput = playerInput;
            _stateMachine = gameStateMachine;
        }

        ~GameStatesSwitcher() => Expose();

        public void Initialize() => Bind();

        private void SetPause()
        {
            if (_stateMachine.CurrentState.GetType() == typeof(PauseState))
                _stateMachine.SwitchState<GameState>();
            else
                _stateMachine.SwitchState<PauseState>();
        }

        private void SetFinal()
        {
            _stateMachine.SwitchState<FinalState>();
        }

        private void Bind()
        {
            _playerInput.OnPause += SetPause;
            _playerInput.OnFinal += SetFinal;
        }

        private void Expose()
        {
            _playerInput.OnPause -= SetPause;
            _playerInput.OnFinal -= SetFinal;
        }
    }
}