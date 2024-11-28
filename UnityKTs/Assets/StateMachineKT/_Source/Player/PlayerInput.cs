using System;
using StateMachineKT.Player.Data;
using UnityEngine;
using Zenject;

namespace StateMachineKT.Player
{
    public class PlayerInput : IFixedTickable, ITickable
    {
        public event Action<Vector2> OnMove;
        public event Action OnAttack;
        public event Action OnStateSwitch;
        public event Action OnPause;
        public event Action OnFinal;

        private readonly PlayerSettingsSO _playerSettings;
        private bool _readInputPause = true;
        private bool _allReadingStopped;

        [Inject]
        public PlayerInput(PlayerSettingsSO playerSettingsSO) => _playerSettings = playerSettingsSO;

        public void FixedTick()
        {
            if(_readInputPause || _allReadingStopped)
                return;
            
            ReadMoveInput();
        }

        public void Tick()
        {
            ReadPauseInput();
            
            if(_readInputPause || _allReadingStopped)
                return;
            
            ReadAttackInput();
            ReadStateSwitchInput();
            ReadFinalInput();
        }

        public void SetReadInputPauseState(bool state) => _readInputPause = state;

        public void StopReadingAllInput() => _allReadingStopped = true;

        private void ReadFinalInput()
        {
            if (Input.GetKeyDown(_playerSettings.FinalKey))
                OnFinal?.Invoke();
        }

        private void ReadPauseInput()
        {
            if (Input.GetKeyDown(_playerSettings.PauseKey))
                OnPause?.Invoke();
        }

        private void ReadAttackInput()
        {
            if (Input.GetKeyDown(_playerSettings.AttackKey))
                OnAttack?.Invoke();
        }

        private void ReadMoveInput()
        {
            OnMove?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }

        private void ReadStateSwitchInput()
        {
            if (Input.GetKeyDown(_playerSettings.SwitchStateKey))
                OnStateSwitch?.Invoke();
        }
    }
}