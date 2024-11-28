using StateMachineKT.StateMachine.Data;

namespace StateMachineKT.Player.PlayerStates
{
    public class ShootState : AState
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerAbilities _playerAbilities;
        
        public ShootState(IStateMachine owner, PlayerInput input, PlayerAbilities playerAbilities) : base(owner)
        {
            _playerInput = input;
            _playerAbilities = playerAbilities;
        }

        private void OnAttack()
        {
            _playerAbilities.Shoot();
        }
        
        public override void Enter()
        {
            _playerInput.OnAttack += OnAttack;
        }

        public override void Exit()
        {
            _playerInput.OnAttack -= OnAttack;
        }
    }
}