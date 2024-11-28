using System;
using System.Collections.Generic;
using StateMachineKT.StateMachine.Data;

namespace StateMachineKT.StateMachine
{
    public class StateMachine<T> : IStateMachine where T : AState
    {
        public IReadOnlyDictionary<Type, T> States => _states;
        
        private readonly Dictionary<Type, T> _states = new();
        public T CurrentState { get; private set; }
        
        public event Action OnStateChanged;

        public bool TryRegisterState(T state) => _states.TryAdd(state.GetType(), state);

        public bool SwitchState<T>() where T : AState
        {
            if (!_states.ContainsKey(typeof(T)))
                return false;
            
            CurrentState?.Exit();
            CurrentState = _states[typeof(T)];
            CurrentState?.Enter();
            
            OnStateChanged?.Invoke();
            
            return true;
        }
    }
}
