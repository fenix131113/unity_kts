using UnityEngine;

namespace StaticKT
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private FormulaViewDataSO[] formulasViewData;
        [SerializeField] private RectTransform blocksParent;
        [SerializeField] private FormulaBlockView formulaBlockPrefab;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            foreach (var item in formulasViewData)
                Instantiate(formulaBlockPrefab, blocksParent).Init(item);
        }
    }
}