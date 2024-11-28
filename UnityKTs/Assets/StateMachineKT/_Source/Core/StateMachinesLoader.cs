using StateMachineKT.GameStates;
using StateMachineKT.GameStates.States;
using StateMachineKT.Player;
using StateMachineKT.Player.PlayerStates;
using Zenject;

namespace StateMachineKT.Core
{
    public class StateMachinesLoader : IInitializable
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly PlayerInput _playerInput;
        private readonly PlayerAbilities _playerAbilities;
        private readonly GameStateMachine _gameStateMachine;

        [Inject]
        public StateMachinesLoader(PlayerStateMachine playerStateMachine, PlayerInput playerInput,
            PlayerAbilities playerAbilities, GameStateMachine gameStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _playerInput = playerInput;
            _playerAbilities = playerAbilities;
            _gameStateMachine = gameStateMachine;

            LoadPlayerStateMachine();
            LoadGameStateMachine();
        }

        private void LoadGameStateMachine()
        {
            _gameStateMachine.TryRegisterState(new GameState(_gameStateMachine, _playerInput));
            _gameStateMachine.TryRegisterState(new PauseState(_gameStateMachine));
            _gameStateMachine.TryRegisterState(new FinalState(_gameStateMachine, _playerInput, _playerAbilities));
        }
        
        private void LoadPlayerStateMachine()
        {
            _playerStateMachine.TryRegisterState(new ShootState(_playerStateMachine, _playerInput, _playerAbilities));
            
            _playerStateMachine.TryRegisterState(
                new RedCircleState(_playerStateMachine, _playerInput, _playerAbilities));
            
            _playerStateMachine.TryRegisterState(
                new InvisibleState(_playerStateMachine, _playerInput, _playerAbilities));
        }

        public void Initialize()
        {
            _playerStateMachine.SwitchState<ShootState>();
            _gameStateMachine.SwitchState<GameState>();
        }
    }
}