using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class SpawnCommand : ICommand
    {
        private readonly GameObject _spawnTarget;
        private readonly List<GameObject> _commandHistory = new();

        public SpawnCommand(GameObject spawnTarget) => _spawnTarget = spawnTarget;

        public void Execute(Vector3 position)
        {
            _commandHistory.Add(Object.Instantiate(_spawnTarget, position, Quaternion.identity));
            
            if (_commandHistory.Count > CommandInvoker.MAX_UNDO_COMMANDS)
                _commandHistory.RemoveAt(0);
        }

        public void Undo()
        {
            Object.Destroy(_commandHistory[^1]);
            _commandHistory.RemoveAt(_commandHistory.Count - 1);
        }
    }
}