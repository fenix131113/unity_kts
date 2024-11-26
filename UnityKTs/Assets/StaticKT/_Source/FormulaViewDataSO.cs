using UnityEngine;

namespace StaticKT
{
    [CreateAssetMenu(fileName = "New FormulaViewDataSO", menuName = "SO/StaticKT/New FormulaViewDataSO")]
    public class FormulaViewDataSO : ScriptableObject
    {
        [field: SerializeField] public string Formula { get; private set; }
        [field: SerializeField] public FormulaType FormulaType { get; private set; }
        [field: SerializeField] public string[] Values { get; private set; }
    }
}