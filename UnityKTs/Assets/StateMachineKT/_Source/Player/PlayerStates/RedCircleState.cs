using StateMachineKT.StateMachine.Data;

namespace StateMachineKT.Player.PlayerStates
{
    public class RedCircleState : AState
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerAbilities _playerAbilities;
        
        private bool _isRedCircleActive;
        
        public RedCircleState(IStateMachine owner, PlayerInput input, PlayerAbilities playerAbilities) : base(owner)
        {
            _playerInput = input;
            _playerAbilities = playerAbilities;
        }

        private void OnAttack()
        {
            _isRedCircleActive = !_isRedCircleActive;
            _playerAbilities.SetRedZoneStatus(_isRedCircleActive);
        }
        
        public override void Enter()
        {
            _playerInput.OnAttack += OnAttack;
        }

        public override void Exit()
        {
            _playerInput.OnAttack -= OnAttack;
            _isRedCircleActive = false;
            _playerAbilities.SetRedZoneStatus(false);
        }
    }
}