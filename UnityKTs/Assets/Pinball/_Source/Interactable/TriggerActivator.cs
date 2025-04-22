using UnityEngine;
using UnityEngine.Events;

namespace Pinball.Interactable
{
    public class TriggerActivator : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTriggerActivated;

        private void OnTriggerEnter(Collider other)
        {
            if(!other.GetComponent<Rigidbody>())
                return;
            
            onTriggerActivated?.Invoke();
        }
    }
}