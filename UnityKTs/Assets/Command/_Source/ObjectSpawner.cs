using UnityEngine;

namespace Command
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        
        private InputListener _inputListener;
        private CommandInvoker _commandInvoker;
        private ICommand _command;
        
        public void Init(InputListener inputListener, CommandInvoker commandInvoker)
        {
            _inputListener = inputListener;
            _commandInvoker = commandInvoker;
            
            _command = new SpawnCommand(prefab);
        }

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void SpawnObject()
        {
            Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            _commandInvoker.Execute(_command, hit.point);
        }

        private void Bind()
        {
            _inputListener.OnSpawnClicked += SpawnObject;
        }

        private void Expose()
        {
            _inputListener.OnSpawnClicked -= SpawnObject;
        }
    }
}