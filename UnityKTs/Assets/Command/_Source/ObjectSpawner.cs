using UnityEngine;

namespace Command
{
    public class ObjectSpawner : MonoBehaviour
    {
        // Вид зависимости: сериализованное поле, можно просто забыть передать зависимость через инспектор и спавн сломается
        [SerializeField] private GameObject prefab;

        private CommandInvoker _commandInvoker;

        public GameObject SpawnObject(Vector3 position)
        {
            var spawned = Instantiate(prefab, position, Quaternion.identity);

            return spawned;
        }
    }
}