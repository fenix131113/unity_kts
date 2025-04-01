using System;
using UnityEngine.UIElements;

namespace ServiceLocator
{
    public interface IFadeService
    {
        void FadeIn(VisualElement image, float duration, Action completeCallback = null);
        void FadeOut(VisualElement image, float duration, Action completeCallback = null);
    }
}