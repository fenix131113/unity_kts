using StateMachineKT.StateMachine.Data;
using UnityEngine;

namespace StateMachineKT.GameStates.States
{
    public class PauseState : AState
    {
        public PauseState(IStateMachine owner) : base(owner)
        {
        }

        public override void Enter()
        {
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            Time.timeScale = 1;
        }
    }
}