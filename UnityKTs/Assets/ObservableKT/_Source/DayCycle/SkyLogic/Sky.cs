using System;
using ObservableKT._Source.Observable;

namespace ObservableKT._Source.DayCycle.SkyLogic
{
    public class Sky : ISubscriber
    {
        public event Action<float> OnSkyColorChanged;
        
        public Sky(IPublisher publisher) => publisher.Register(this);

        public void Notify(float progress) => OnSkyColorChanged?.Invoke(progress);
    }
}