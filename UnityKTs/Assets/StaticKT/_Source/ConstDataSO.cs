using UnityEngine;

namespace StaticKT
{
    [CreateAssetMenu(fileName = "ConstDataSO", menuName = "SO/StaticKT/New ConstDataSO")]
    public class ConstDataSO : ScriptableObject
    {
        [field: SerializeField] public double ConstValue { get; private set; }
    }
}
