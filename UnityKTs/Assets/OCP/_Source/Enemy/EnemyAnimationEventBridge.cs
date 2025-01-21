using UnityEngine;

namespace OCP._Source.Enemy
{
    public class EnemyAnimationEventBridge : MonoBehaviour
    {
        [SerializeField] private AEnemy enemy;
        
        public void Attack() => enemy.Attack();
    }
}