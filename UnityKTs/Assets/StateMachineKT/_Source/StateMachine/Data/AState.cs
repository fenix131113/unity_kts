namespace StateMachineKT.StateMachine.Data
{
    public abstract class AState
    {
        protected IStateMachine _owner;

        protected AState(IStateMachine owner) => _owner = owner;

        public virtual void Enter(){}
        public virtual void Exit(){}
    }
}