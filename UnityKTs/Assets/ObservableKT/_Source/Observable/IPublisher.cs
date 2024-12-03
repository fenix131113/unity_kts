namespace ObservableKT._Source.Observable
{
    public interface IPublisher
    {
        void Register(ISubscriber subscriber);
        void Unregister(ISubscriber subscriber);
        void Publish(float progress);
    }
}