using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ObjectPool
{
    internal sealed class ViewServices
    {
        private readonly Dictionary<Type, IObjectPool> _viewCache = new Dictionary<Type, IObjectPool>(12);

        public T Instantiate<T>() where T : new()
        {
                return GetOrAdd<T>().Pop();
        }

        public void Destroy<T>(T value) where T : new()
        {
            GetOrAdd<T>().Push(value);
        }

        private ObjectPool<T> GetOrAdd<T>() where T : new()
        {
            if (!_viewCache.TryGetValue(typeof(T), out IObjectPool viewPool))
            {
                viewPool = new ObjectPool<T>();
                _viewCache[typeof(T)] = viewPool;
            }

                return (ObjectPool<T>)viewPool;
        }
    }

}