using TMPro;
using UnityEngine;
using Zenject;

namespace StateMachineKT.Player.View
{
    public class CurrentStateView : MonoBehaviour
    {
        [SerializeField] private TMP_Text stateLabel;

        private PlayerStateMachine _stateMachine;
        
        [Inject]
        private void Construct(PlayerStateMachine stateMachine) => _stateMachine = stateMachine;

        private void Awake() => Bind();

        private void OnDestroy() => Expose();

        private void DrawState() => stateLabel.text = _stateMachine.CurrentState.GetType().Name;

        private void Bind() => _stateMachine.OnStateChanged += DrawState;

        private void Expose() => _stateMachine.OnStateChanged -= DrawState;
    }
}