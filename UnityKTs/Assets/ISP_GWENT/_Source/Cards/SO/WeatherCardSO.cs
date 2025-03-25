using UnityEngine;

namespace ISP_GWENT.Cards.SO
{
    [CreateAssetMenu(fileName = "Weather Card", menuName = "SO/GWENT/Weather Card")]
    public class WeatherCardSO : CardSO, IWeatherCard
    {
        public virtual void UserWeatherEffect()
        {
            Debug.Log($"{CardName} use weather effect");
        }
    }
}