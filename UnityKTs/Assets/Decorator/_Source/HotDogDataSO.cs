using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "New HotDog Data", menuName = "Decorator/HotDog Data")]
    public class HotDogDataSO : ScriptableObject
    {
        [field: SerializeField] public string HotDogName { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public int Weight { get; private set; }
    }
}