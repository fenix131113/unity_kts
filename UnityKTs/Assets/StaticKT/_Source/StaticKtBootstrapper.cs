using UnityEngine;

namespace StaticKT
{
    public class StaticKtBootstrapper : MonoBehaviour
    {
        [SerializeField] private ConstDataSO gravityConst;
        [SerializeField] private ConstDataSO universalGravityConst;

        private void Awake()
        {
            Calculator.SetData(gravityConst, universalGravityConst);
        }
    }
}