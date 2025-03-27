using UnityEngine;

namespace Command
{
    public class Bootstrapper : MonoBehaviour
    {
        // Вид зависимости: сериализованное поле, можно просто забыть передать зависимость через инспектор и спавн сломается
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Character character;
        [SerializeField] private ObjectSpawner spawner;

        private CommandInvoker _commandInvoker;
        private InvokerHandler _invokerHandler;

        private void Awake()
        {
            // Вид зависимости: инкапсулированная зависимость, неявно, что класс имеет зависимости при Awake, может вызвать проблемы при отладке 
            _commandInvoker = new CommandInvoker();
            _invokerHandler = new InvokerHandler(_commandInvoker, inputListener, new TeleportCommand(character),
                new SpawnCommand(spawner));
        }
    }
}