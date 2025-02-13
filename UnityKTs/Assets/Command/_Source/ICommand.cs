using UnityEngine;

namespace Command
{
    public interface ICommand
    {
        void Execute(Vector3 position);
        void Undo();
    }
}