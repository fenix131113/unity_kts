using UnityEngine;

namespace Command
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Character character;
        [SerializeField] private ObjectSpawner spawner;

        private CommandInvoker _commandInvoker;
        private InvokerHandler _invokerHandler;

        private void Awake()
        {
            _commandInvoker = new CommandInvoker();
            _invokerHandler = new InvokerHandler(_commandInvoker, inputListener, new TeleportCommand(character),
                new SpawnCommand(spawner));
        }
    }
}