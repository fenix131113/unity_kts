using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class TeleportCommand : ICommand
    {
        private readonly Character _teleportTarget;
        private readonly List<Vector3> _commandHistory = new();

        public  TeleportCommand(Character teleportTarget) => _teleportTarget = teleportTarget;

        public void Execute(Vector3 position)
        {
            _commandHistory.Add(_teleportTarget.transform.position);

            if (_commandHistory.Count > CommandInvoker.MAX_UNDO_COMMANDS)
                _commandHistory.RemoveAt(0);
            
            _teleportTarget.Teleport(position);
        }

        public void Undo()
        {
            _teleportTarget.Teleport(_commandHistory[^1]);
            _commandHistory.RemoveAt(_commandHistory.Count - 1);
        }
    }
}