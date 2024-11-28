using UnityEngine;

namespace StateMachineKT.Player.Data
{
    [CreateAssetMenu(fileName = "New PlayerSettingsSO", menuName = "SO/StateMachineKT/PlayerSettingsSO")]
    public class PlayerSettingsSO : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public KeyCode AttackKey { get; private set; }
        [field: SerializeField] public KeyCode SwitchStateKey { get; private set; }
        [field: SerializeField] public KeyCode PauseKey { get; private set; }
        [field: SerializeField] public KeyCode FinalKey { get; private set; }
    }
}