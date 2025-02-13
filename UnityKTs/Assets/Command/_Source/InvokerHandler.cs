using UnityEngine;

namespace Command
{
    public class InvokerHandler
    {
        private readonly CommandInvoker _invoker;
        private readonly ICommandActions _commandsActions;
        private readonly TeleportCommand _teleportCommand;
        private readonly SpawnCommand _spawnCommand;

        public InvokerHandler(CommandInvoker invoker, ICommandActions commandsActions,TeleportCommand teleportCommand, SpawnCommand spawnCommand)
        {
            _invoker = invoker;
            _commandsActions = commandsActions;
            _teleportCommand = teleportCommand;
            _spawnCommand = spawnCommand;
            
            Bind();
        }

        ~InvokerHandler() => Expose();
        
        private void InvokeSpawnCommand()
        {
            Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out var hit);
            _invoker.Execute(_spawnCommand, hit.point);
        }

        private void InvokeTeleportCommand()
        {
            Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out var hit);
            _invoker.Execute(_teleportCommand, hit.point);
        }
        
        private void Bind()
        {
            _commandsActions.OnTeleportClicked += InvokeTeleportCommand;
            _commandsActions.OnSpawnClicked += InvokeSpawnCommand;
            _commandsActions.OnExecuteAllClicked += _invoker.ExecuteAll;
            _commandsActions.OnUndoClicked += _invoker.Undo;
        }

        private void Expose()
        {
            _commandsActions.OnTeleportClicked -= InvokeTeleportCommand;
            _commandsActions.OnSpawnClicked -= InvokeSpawnCommand;
            _commandsActions.OnExecuteAllClicked -= _invoker.ExecuteAll;
            _commandsActions.OnUndoClicked -= _invoker.Undo;
        }
    }
}