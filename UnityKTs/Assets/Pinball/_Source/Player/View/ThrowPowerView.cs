using UnityEngine;
using UnityEngine.UI;

namespace Pinball.Player.View
{
    public class ThrowPowerView : MonoBehaviour
    {
        [SerializeField] private Image filler;
        [SerializeField] private Gradient fillGradient;

        private BallThrower _thrower;

        public void Construct(BallThrower thrower) => _thrower = thrower;

        private void Update()
        {
            if (_thrower.IsThrown)
            {
                filler.fillAmount = 0f;
                return;
            }

            filler.fillAmount = _thrower.PowerProgress;
            filler.color = fillGradient.Evaluate(_thrower.PowerProgress);
        }
    }
}