namespace Decorator
{
    public abstract class HotDogDecorator : HotDog
    {
        protected readonly HotDog HotDog;
        protected readonly HotDogDecoratorDataSO HotDogDecoratorData;
        
        public HotDogDecorator(HotDogDecoratorDataSO hotDogDecoratorData, HotDog hotDog) : base(hotDog.GetName(), hotDog.GetWeight(), hotDog.GetCost())
        {
            HotDogDecoratorData = hotDogDecoratorData;
            HotDog = hotDog;
        }
    }
}