namespace Decorator
{
    public class SweetOnionHotDogDecorator : HotDogDecorator
    {
        public SweetOnionHotDogDecorator(HotDogDecoratorDataSO hotDogDecoratorData, HotDog hotDog) : base(hotDogDecoratorData, hotDog)
        {
        }

        public override string GetName() => HotDog.GetName() + HotDogName;

        public override int GetCost() => HotDog.GetCost() + Cost;
        public override int GetWeight() => HotDog.GetWeight() + Weight;
    }
}