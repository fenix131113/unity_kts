namespace ObservableKT._Source.Observable
{
    public interface ISubscriber
    {
        void Notify(float progress);
    }
}