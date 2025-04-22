using System;
using UnityEngine;

namespace Pinball.Interactable
{
    public class DeadZone : MonoBehaviour
    {
        public event Action OnBallReachedDeadZone;
        
        private void OnTriggerEnter(Collider other)
        {
            if(!other.GetComponent<Rigidbody>())
                return;
            
            OnBallReachedDeadZone?.Invoke();
        }
    }
}