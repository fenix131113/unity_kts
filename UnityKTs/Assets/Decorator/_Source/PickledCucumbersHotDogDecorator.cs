namespace Decorator
{
    public class PickledCucumbersHotDogDecorator : HotDogDecorator
    {
        public PickledCucumbersHotDogDecorator(HotDogDecoratorDataSO hotDogDecoratorData, HotDog hotDog) : base(hotDogDecoratorData, hotDog)
        {
        }

        public override string GetName() => HotDog.GetName() + HotDogDecoratorData.Postfix;

        public override int GetCost() => HotDog.GetCost() + HotDogDecoratorData.Cost;
        public override int GetWeight() => HotDog.GetWeight() + HotDogDecoratorData.Weight;
    }
}