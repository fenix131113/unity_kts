using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandInvoker
    {
        public const int MAX_UNDO_COMMANDS = 10;
        private readonly List<ICommand> _commandsHistory = new();
        private readonly ICommandActions _commandsActions;
        private readonly List<KeyValuePair<ICommand, Vector3>> _commandsToInvoke = new();

        private readonly TeleportCommand _teleportCommand;
        private readonly SpawnCommand _spawnCommand;

        public CommandInvoker(ICommandActions commandsActions, TeleportCommand teleportCommand, SpawnCommand spawnCommand)
        {
            _commandsActions = commandsActions;
            _teleportCommand = teleportCommand;
            _spawnCommand = spawnCommand;
            Bind();
        }

        ~CommandInvoker() => Expose();

        private void InvokeSpawnCommand()
        {
            Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out var hit);
            Execute(_spawnCommand, hit.point);
        }

        private void InvokeTeleportCommand()
        {
            Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out var hit);
            Execute(_teleportCommand, hit.point);
        }

        public void Execute(ICommand command, Vector3 position)
        {
            if (command is SpawnCommand)
                _commandsToInvoke.Add(new KeyValuePair<ICommand, Vector3>(command, position));
            else
            {
                command.Execute(position);
                _commandsHistory.Add(command);

                if (_commandsHistory.Count > MAX_UNDO_COMMANDS)
                    _commandsHistory.RemoveAt(0);
            }
        }

        private void ExecuteAll()
        {
            foreach (var command in _commandsToInvoke)
            {
                command.Key.Execute(command.Value);
                _commandsHistory.Add(command.Key);

                if (_commandsHistory.Count > MAX_UNDO_COMMANDS)
                    _commandsHistory.RemoveAt(0);
            }

            _commandsToInvoke.Clear();
        }

        public void Undo()
        {
            if (_commandsHistory.Count == 0)
                return;

            _commandsHistory[^1].Undo();
            _commandsHistory.RemoveAt(_commandsHistory.Count - 1);
        }

        private void Bind()
        {
            _commandsActions.OnTeleportClicked += InvokeTeleportCommand;
            _commandsActions.OnSpawnClicked += InvokeSpawnCommand;
            _commandsActions.OnExecuteAllClicked += ExecuteAll;
            _commandsActions.OnUndoClicked += Undo;
        }

        private void Expose()
        {
            _commandsActions.OnTeleportClicked -= InvokeTeleportCommand;
            _commandsActions.OnSpawnClicked -= InvokeSpawnCommand;
            _commandsActions.OnExecuteAllClicked -= ExecuteAll;
            _commandsActions.OnUndoClicked -= Undo;
        }
    }
}