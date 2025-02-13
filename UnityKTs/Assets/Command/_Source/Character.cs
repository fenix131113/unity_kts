using UnityEngine;

namespace Command
{
    public class Character : MonoBehaviour
    {
        public void Teleport(Vector3 position)
        {
            transform.position = position;
        }
    }
}