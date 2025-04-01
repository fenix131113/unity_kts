using System;
using System.Collections.Generic;

namespace ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> _services = new();

        public void RegisterService<T>(T instance) => _services.TryAdd(instance.GetType(), instance);

        public bool GetService<T>(out T service)
        {
            if (_services.ContainsKey(typeof(T)))
            {
                service = (T)_services[typeof(T)];
                return true;
            }

            service = default;
            return false;
        }
    }
}