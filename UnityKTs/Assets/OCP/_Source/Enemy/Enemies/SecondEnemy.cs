using UnityEngine;

namespace OCP._Source.Enemy.Enemies
{
    public class SecondEnemy : AEnemy
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        
        private static readonly int _attackKey = Animator.StringToHash("SecondAttack");

        public override void OnSpawn()
        {
            EnemyAnimator.SetTrigger(_attackKey);
        }

        public override void Attack()
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}