namespace ServiceLocator
{
    public class Score
    {
        public int Count { get; private set; }

        public void Increase() => Count++;
    }
}