namespace Decorator
{
    public class PickledCucumbersHotDogDecorator : HotDogDecorator
    {
        public PickledCucumbersHotDogDecorator(HotDogDecoratorDataSO hotDogDecoratorData, HotDog hotDog) : base(hotDogDecoratorData, hotDog)
        {
        }

        public override string GetName() => HotDog.GetName() + HotDogName;

        public override int GetCost() => HotDog.GetCost() + Cost;
        public override int GetWeight() => HotDog.GetWeight() + Weight;
    }
}