using OCP._Source.Attack;
using OCP._Source.Attack.View;
using UnityEngine;

namespace OCP._Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private AttackPerformer attackPerformer;
        [SerializeField] private AttackButtonsContainer attackButtonsContainer;
        
        private void Awake()
        {
            inputListener.Init(attackPerformer);
            attackButtonsContainer.Init(attackPerformer);
        }
    }
}