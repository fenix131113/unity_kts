using System;
using ObservableKT._Source.Observable;

namespace ObservableKT._Source.DayCycle.StarLogic
{
    public class Star : ISubscriber
    {
        public event Action<float> OnStarProgressChanged;
        public Star(IPublisher publisher)
        {
            publisher.Register(this);
        }
        
        public void Notify(float progress)
        {
            OnStarProgressChanged?.Invoke(progress);
        }
    }
}