using System;
using DG.Tweening;
using UnityEngine.UIElements;

namespace ServiceLocator
{
    public class FadeService : IFadeService
    {
        public void FadeIn(VisualElement image, float duration, Action completeCallback = null)
        {
            DOTween.To(() => image.style.opacity.value,
                    newValue => image.style.opacity = newValue, 0f, duration).onComplete +=
                () => completeCallback?.Invoke();
        }

        public void FadeOut(VisualElement image, float duration, Action completeCallback = null)
        {
            DOTween.To(() => image.style.opacity.value,
                    newValue => image.style.opacity = newValue, 1f, duration).onComplete +=
                () => completeCallback?.Invoke();
        }
    }
}