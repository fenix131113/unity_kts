using UnityEngine;

namespace OCP._Source.Enemy
{
    public class AEnemy : MonoBehaviour
    {
        [field: SerializeField] public Animator EnemyAnimator { get; protected set; }

        public virtual void OnSpawn()
        {
        }

        public virtual void Attack()
        {
        }
    }
}
