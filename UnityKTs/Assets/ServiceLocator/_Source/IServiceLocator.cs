namespace ServiceLocator
{
    public interface IServiceLocator
    {
        bool GetService<T>(out T service);
    }
}