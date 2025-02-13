using UnityEngine;

namespace Command
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        private CommandInvoker _commandInvoker;

        public GameObject SpawnObject(Vector3 position)
        {
            var spawned = Instantiate(prefab, position, Quaternion.identity);

            return spawned;
        }
    }
}