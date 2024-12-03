using System;
using ObservableKT._Source.Observable;

namespace ObservableKT._Source.DayCycle.SunLogic
{
    public class Sun : ISubscriber
    {
        public event Action<float> OnSunNotified;
        
        public Sun(IPublisher publisher) => publisher.Register(this);

        public void Notify(float progress)
        {
            OnSunNotified?.Invoke(progress);
        }
    }
}