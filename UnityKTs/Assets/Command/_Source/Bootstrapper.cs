using UnityEngine;

namespace Command
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Character character;
        [SerializeField] private ObjectSpawner spawner;
        
        private CommandInvoker _commandInvoker;
        
        private void Awake()
        {
            _commandInvoker = new CommandInvoker(inputListener);
            character.Init(inputListener, _commandInvoker);
            spawner.Init(inputListener, _commandInvoker);
        }
    }
}