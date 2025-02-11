namespace Decorator
{
    public abstract class HotDog
    {
        protected readonly string HotDogName;
        protected readonly int Weight;
        protected int Cost;

        public HotDog(string hotDogName, int weight, int cost)
        {
            HotDogName = hotDogName;
            Weight = weight;
            Cost = cost;
        }
        
        public abstract string GetName();
        public abstract int GetCost();
        public abstract int GetWeight();
    }
}
