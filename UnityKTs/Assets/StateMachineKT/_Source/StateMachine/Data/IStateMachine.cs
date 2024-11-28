namespace StateMachineKT.StateMachine.Data
{
    public interface IStateMachine
    {
        bool SwitchState<T>() where T : AState;
    }
}