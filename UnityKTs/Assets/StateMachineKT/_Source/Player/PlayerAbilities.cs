using UnityEngine;

namespace StateMachineKT.Player
{
    public class PlayerAbilities : MonoBehaviour
    {
        [Header("Shoot")] [SerializeField] private Transform shootPoint;
        [SerializeField] private GameObject bulletPrefab;

        [Header("Red Zone")] [SerializeField] private GameObject redZone;

        [Header("Invisible")] [SerializeField] private SpriteRenderer playerRenderer;

        public void Shoot() => Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        public void SetRedZoneStatus(bool status) => redZone.SetActive(status);

        public void SetPlayerInvisibleStatus(bool status) =>
            playerRenderer.color = status ? new Color(1f, 1f, 1f, 0.25f) : Color.green;
    }
}