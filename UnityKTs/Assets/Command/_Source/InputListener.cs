using System;
using UnityEngine;

namespace Command
{
    public class InputListener : MonoBehaviour
    {
        public event Action OnSpawnClicked;
        public event Action OnTeleportClicked;
        public event Action OnUndoClicked;
        public event Action OnExecuteAllClicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnSpawnClicked?.Invoke();
            if (Input.GetMouseButtonDown(1))
                OnTeleportClicked?.Invoke();
            if (Input.GetMouseButtonDown(2))
                OnUndoClicked?.Invoke();
            if (Input.GetKeyDown(KeyCode.Return))
                OnExecuteAllClicked?.Invoke();
        }
    }
}