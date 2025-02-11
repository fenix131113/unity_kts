namespace Decorator.HotDogs
{
    public class CaesarHotDog : HotDog
    {
        public CaesarHotDog(string name, int weight, int cost) : base(name, weight, cost)
        {
        }

        public override string GetName() => HotDogName;

        public override int GetCost() => Cost;
        public override int GetWeight() => Weight;
    }
}