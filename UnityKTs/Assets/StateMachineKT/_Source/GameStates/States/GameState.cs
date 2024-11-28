using StateMachineKT.Player;
using StateMachineKT.StateMachine.Data;

namespace StateMachineKT.GameStates.States
{
    public class GameState : AState
    {
        private PlayerInput _playerInput;
        
        public GameState(IStateMachine owner, PlayerInput playerInput) : base(owner)
        {
            _playerInput = playerInput;
        }

        public override void Enter()
        {
            _playerInput.SetReadInputPauseState(false);
        }

        public override void Exit()
        {
            _playerInput.SetReadInputPauseState(true);
        }
    }
}