using System;

namespace Command
{
    public interface ICommandActions
    {
        event Action OnSpawnClicked;
        event Action OnTeleportClicked;
        event Action OnUndoClicked;
        event Action OnExecuteAllClicked;
    }
}