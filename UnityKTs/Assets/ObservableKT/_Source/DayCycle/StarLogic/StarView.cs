using UnityEngine;

namespace ObservableKT._Source.DayCycle.StarLogic
{
    public class StarView : MonoBehaviour
    {
        private const float FADE_DOWN_OFFSET = 0.3f;
        private const float FADE_UP_OFFSET = 0.4f;
        
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
                <= FADE_DOWN_OFFSET => new Color(255, 255, 255, Mathf.Clamp(FADE_DOWN_OFFSET - progress / FADE_DOWN_OFFSET, 0, 1f)),
                >= FADE_UP_OFFSET => new Color(255, 255, 255, Mathf.Clamp((progress - FADE_UP_OFFSET) / (1 - FADE_UP_OFFSET), 0, 1f)),
                _ => starRenderer.color
            };
        }

        private void Bind() => _star.OnStarProgressChanged += CheckStarProgress;

        private void Expose() => _star.OnStarProgressChanged -= CheckStarProgress;
    }
}