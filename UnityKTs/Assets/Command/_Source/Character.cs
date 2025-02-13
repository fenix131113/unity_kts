using UnityEngine;

namespace Command
{
    public class Character : MonoBehaviour
    {
        private InputListener _inputListener;
        private CommandInvoker _commandInvoker;
        private ICommand _command;
        
        public void Init(InputListener inputListener, CommandInvoker commandInvoker)
        {
            _inputListener = inputListener;
            _commandInvoker = commandInvoker;

            _command = new TeleportCommand(gameObject);
        }

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void TeleportToMouse()
        {
            Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            _commandInvoker.Execute(_command, hit.point);
        }

        private void Bind()
        {
            _inputListener.OnTeleportClicked += TeleportToMouse;
        }

        private void Expose()
        {
            _inputListener.OnTeleportClicked -= TeleportToMouse;
        }
    }
}