using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "New HotDog Decorator Data", menuName = "Decorator/HotDog Decorator Data")]
    public class HotDogDecoratorDataSO : ScriptableObject
    {
        [field: SerializeField] public string Postfix { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public int Weight { get; private set; }
    }
}