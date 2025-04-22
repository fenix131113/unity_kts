using UnityEngine;

namespace Pinball.Interactable
{
    public class Bouncer : AScoresGiver
    {
        [SerializeField] private float force;

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Rigidbody rb))
                return;

            base.OnTriggerEnter(other);

            rb.linearVelocity = Vector3.zero;
            var forceVector = rb.transform.position - transform.position;
            forceVector.Normalize();

            forceVector.y = 0f;

            rb.AddForce(forceVector * force, ForceMode.Impulse);
        }
    }
}