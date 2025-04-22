using System;
using UnityEngine;

namespace Pinball.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnThrowInput;
        public event Action OnThrowUp;
        public event Action OnLeftFlipperInput;
        public event Action OnRightFlipperInput;
        public event Action OnRestartInput;

        private void Update()
        {
            ReadThrowInput();
            ReadFlippersInput();
            ReadRestartInput();
        }

        private void ReadThrowInput()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
                OnThrowInput?.Invoke();
            
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
                OnThrowUp?.Invoke();
        }

        private void ReadFlippersInput()
        {
            if(Input.GetKeyDown(KeyCode.Z))
                OnLeftFlipperInput?.Invoke();
            
            if(Input.GetKeyDown(KeyCode.X))
                OnRightFlipperInput?.Invoke();
        }

        private void ReadRestartInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
                OnRestartInput?.Invoke();
        }
    }
}