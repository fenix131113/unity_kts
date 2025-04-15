using System.Linq;
using UnityEngine;

namespace ZenjectKT
{
    public class TargetsContainer : MonoBehaviour
    {
        [SerializeField] private Transform[] targets;

        public Transform GetScreenTarget() => targets.FirstOrDefault(IsObjectVisible);

        private bool IsObjectVisible(Transform target)
        {
            var viewportPos = Camera.main!.WorldToViewportPoint(target.position);

            return viewportPos is { z: > 0, x: >= 0 and <= 1, y: >= 0 and <= 1 };
        }
    }
}