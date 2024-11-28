using StateMachineKT.Player;
using StateMachineKT.StateMachine.Data;
using UnityEngine;

namespace StateMachineKT.GameStates.States
{
    public class FinalState : AState
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerAbilities _playerAbilities;

        public FinalState(IStateMachine owner, PlayerInput playerInput, PlayerAbilities playerAbilities) : base(owner)
        {
            _playerInput = playerInput;
            _playerAbilities = playerAbilities;
        }

        public override void Enter()
        {
            _playerInput.StopReadingAllInput();
            Time.timeScale = 0;
            _playerAbilities.SetPlayerInvisibleStatus(false);
            _playerAbilities.SetRedZoneStatus(false);
        }
    }
}