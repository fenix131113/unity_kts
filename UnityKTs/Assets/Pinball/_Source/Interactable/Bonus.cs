using System;
using UnityEngine;

namespace Pinball.Interactable
{
    public class Bonus : AScoresGiver
    {
        public event Action<Bonus> OnBonusGained;

        private void OnDestroy() => OnBonusGained = null;

        protected override void OnTriggerEnter(Collider other)
        {
            if(!other.GetComponent<Rigidbody>())
                return;
            
            base.OnTriggerEnter(other);
            OnBonusGained?.Invoke(this);
        }
    }
}