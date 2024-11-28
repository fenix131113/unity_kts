using StateMachineKT.Player.PlayerStates;
using Zenject;

namespace StateMachineKT.Player
{
    public class PlayerStateSwitcher : IInitializable
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerStateMachine _playerStateMachine;
        
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
            switch (_playerStateMachine.CurrentState)
            {
                case InvisibleState:
                    _playerStateMachine.SwitchState<ShootState>();
                    break;
                case ShootState:
                    _playerStateMachine.SwitchState<RedCircleState>();
                    break;
                case RedCircleState:
                    _playerStateMachine.SwitchState<InvisibleState>();
                    break;
            }
        }

        private void Bind() => _playerInput.OnStateSwitch += SwitchStates;

        private void Expose() => _playerInput.OnStateSwitch -= SwitchStates;
    }
}