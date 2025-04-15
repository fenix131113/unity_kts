using System.Collections.Generic;

namespace ZenjectKT.Core
{
    public class ObjectPool<T>
    {
        private readonly List<T> _pool = new();

        public void Push(T obj)
        {
            if (!_pool.Contains(obj))
                _pool.Add(obj);
        }

        public T Pop()
        {
            var result = _pool.Count == 0 ? default : _pool[^1];
            
            if (_pool.Count > 0)
                _pool.RemoveAt(_pool.Count - 1);
            
            return result;
        }
    }
}