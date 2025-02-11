namespace Decorator.HotDogs
{
    public class MeatHotDog : HotDog
    {
        public MeatHotDog(string name, int weight, int cost) : base(name, weight, cost)
        {
        }

        public override string GetName() => HotDogName;

        public override int GetCost() => Cost;
        public override int GetWeight() => Weight;
    }
}