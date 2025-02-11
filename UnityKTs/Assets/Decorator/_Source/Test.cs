using Decorator.HotDogs;
using UnityEngine;

namespace Decorator
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private HotDogDataSO classicHotDogData;
        [SerializeField] private HotDogDecoratorDataSO pickledData;
        [SerializeField] private HotDogDecoratorDataSO sweetOnionData;
        
        private void Start()
        {
            var classic = new ClassicHotDog(classicHotDogData.HotDogName, classicHotDogData.Weight, classicHotDogData.Cost);

            Debug.Log(classic.GetName() + $"({classic.GetWeight()}г)" + " - " + classic.GetCost() + "р.");
            var pickled = new PickledCucumbersHotDogDecorator(pickledData, classic);
            var onion = new SweetOnionHotDogDecorator(sweetOnionData, classic);

            Debug.Log(pickled.GetName() + $"({pickled.GetWeight()}г)" + " - " + pickled.GetCost() + "р.");
            Debug.Log(onion.GetName() + $"({onion.GetWeight()}г)" + " - " + onion.GetCost() + "р.");
        }
    }
}