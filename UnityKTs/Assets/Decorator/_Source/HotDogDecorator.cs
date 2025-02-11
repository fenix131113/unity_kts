namespace Decorator
{
    public abstract class HotDogDecorator : HotDog
    {
        protected readonly HotDog HotDog;
        
        public HotDogDecorator(HotDogDecoratorDataSO hotDogDecoratorData, HotDog hotDog) : base(hotDogDecoratorData.Postfix, hotDogDecoratorData.Weight, hotDogDecoratorData.Cost)
        {
            HotDog = hotDog;
        }
    }
}