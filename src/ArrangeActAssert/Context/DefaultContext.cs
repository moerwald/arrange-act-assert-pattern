using System.Collections.Generic;
using System;

namespace ArrangeActAssert.Context
{
    public class DefaultContext  : IContext
    {
        Dictionary<string, (object, Type)> _parameters = new Dictionary<string, (object, Type)>();

        public DefaultContext()
        {
        }

        public void Add<T>(string name, T value)
        {
            _parameters[name] = (value, typeof(T));
        }

        public T Get<T>(string v)
        {
            throw new System.NotImplementedException();
        }
    }
}