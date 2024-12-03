using UnityEngine;

namespace ObservableKT._Source.DayCycle.SkyLogic
{
    public class SkyView : MonoBehaviour
    {
        [SerializeField] private Gradient skyColors;
        [SerializeField] private Camera skyCamera;
        
        private Sky _sky;

        private void OnDestroy() => Expose();

        public void Init(Sky sky)
        {
            _sky = sky;
            Bind();
        }

        private void SetColor(float cycleProgress)
        {
            skyCamera.backgroundColor = skyColors.Evaluate(cycleProgress);
        }

        private void Bind()
        {
            _sky.OnSkyColorChanged += SetColor;
        }

        private void Expose()
        {
            _sky.OnSkyColorChanged -= SetColor;
        }
    }
}