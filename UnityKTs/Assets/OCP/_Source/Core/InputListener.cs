using OCP._Source.Attack;
using UnityEngine;

namespace OCP._Source.Core
{
    public class InputListener : MonoBehaviour
    {
        private AttackPerformer _performer;

        public void Init(AttackPerformer performer) => _performer = performer;

        private void Update() => ReadAttackInput();

        private void ReadAttackInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                _performer.Attack();
        }
    }
}