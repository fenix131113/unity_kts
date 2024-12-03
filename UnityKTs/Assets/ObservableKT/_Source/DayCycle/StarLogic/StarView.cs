using UnityEngine;

namespace ObservableKT._Source.DayCycle.StarLogic
{
    public class StarView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer starRenderer;

        private Star _star;

        private void OnDestroy() => Expose();

        public void Init(Star star)
        {
            _star = star;
            Bind();
        }

        private void CheckStarProgress(float progress)
        {
            starRenderer.color = progress switch
            {
                <= 0.3f => new Color(255, 255, 255, Mathf.Clamp(0.3f - progress / 0.3f, 0, 1f)),
                >= 0.4f => new Color(255, 255, 255, Mathf.Clamp((progress - 0.4f) / 0.6f, 0, 1f)),
                _ => starRenderer.color
            };
        }

        private void Bind() => _star.OnStarProgressChanged += CheckStarProgress;

        private void Expose() => _star.OnStarProgressChanged -= CheckStarProgress;
    }
}