using StateMachineKT.Player.PlayerStates;
using Zenject;

namespace StateMachineKT.Player
{
    public class PlayerStateSwitcher : IInitializable
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerStateMachine _playerStateMachine;

        private int _currentStateIndex;
        
        [Inject]
        public PlayerStateSwitcher(PlayerInput playerInput, PlayerStateMachine playerStateMachine)
        {
            _playerInput = playerInput;
            _playerStateMachine = playerStateMachine;
        }

        ~PlayerStateSwitcher() => Expose();
        
        public void Initialize()
        {
            Bind();
        }

        private void SwitchStates()
        {
            if (_currentStateIndex + 1 < _playerStateMachine.States.Count)
                _currentStateIndex++;
            else
                _currentStateIndex = 0;

            switch (_currentStateIndex)
            {
                case 0:
                    _playerStateMachine.SwitchState<ShootState>();
                    break;
                case 1:
                    _playerStateMachine.SwitchState<RedCircleState>();
                    break;
                case 2:
                    _playerStateMachine.SwitchState<InvisibleState>();
                    break;
            }
        }

        private void Bind() => _playerInput.OnStateSwitch += SwitchStates;

        private void Expose() => _playerInput.OnStateSwitch -= SwitchStates;
    }
}