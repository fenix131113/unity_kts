using System;
using System.Collections.Generic;

namespace ServiceLocator.Ui
{
    public class UiSwitcher
    {
        private readonly Dictionary<Type, IUiState> _uiStates = new();
        private IUiState _currentState;

        public void Switch<T>() where T : IUiState
        {
            if (typeof(T).IsInterface)
                return;

            _currentState?.Exit();
            _currentState = _uiStates[typeof(T)];
            _currentState.Enter();
        }

        public void RegisterState(IUiState state) => _uiStates.TryAdd(state.GetType(), state);
    }
}