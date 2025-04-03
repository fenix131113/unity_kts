using UnityEngine;

namespace ServiceLocator
{
    public class SoundPlayerSetup : MonoBehaviour
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        [field: SerializeField] public AudioClip OpenPanelSound { get; private set; }
        [field: SerializeField] public AudioClip ClosePanelSound { get; private set; }
    }
}