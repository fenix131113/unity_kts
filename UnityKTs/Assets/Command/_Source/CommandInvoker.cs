using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandInvoker
    {
        public const int MAX_UNDO_COMMANDS = 10;
        private readonly List<ICommand> _commandsHistory = new();
        private readonly InputListener _inputListener;
        private readonly List<KeyValuePair<ICommand, Vector3>> _commandsToInvoke = new();

        public CommandInvoker(InputListener inputListener)
        {
            _inputListener = inputListener;
            Bind();
        }

        ~CommandInvoker() => Expose();

        public void Execute(ICommand command, Vector3 position)
        {
            if (command is TeleportCommand)
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
            _inputListener.OnUndoClicked += Undo;
            _inputListener.OnExecuteAllClicked += ExecuteAll;
        }

        private void Expose()
        {
            _inputListener.OnUndoClicked -= Undo;
            _inputListener.OnExecuteAllClicked -= ExecuteAll;
        }
    }
}