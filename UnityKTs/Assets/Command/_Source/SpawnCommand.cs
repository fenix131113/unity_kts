using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class SpawnCommand : ICommand
    {
        private readonly List<GameObject> _commandHistory = new();
        private readonly ObjectSpawner _spawner;

        //Вид зависимости: конструктор
        public SpawnCommand(ObjectSpawner spawner)
        {
            _spawner = spawner;
        }

        public void Execute(Vector3 position)
        {
            _commandHistory.Add(_spawner.SpawnObject(position));
            
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