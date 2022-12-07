using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool
{
    internal interface IObjectPool
    {
    }
    internal sealed class ObjectPool<T> :IObjectPool where T: new()
    {
        private readonly Stack<T> _stack = new Stack<T>();

        public T Pop()
        {
            T objct;
            if (_stack.Count == 0)
            {
                objct = new T();
            }
            else
            {
                objct = _stack.Pop();
            }

            return objct;
        }

        public void Push(T objct)
        {
            if(_stack.Contains(objct)) throw new Exception("re-deleting an object: " + nameof(objct));
            _stack.Push(objct);
        }

    }
}