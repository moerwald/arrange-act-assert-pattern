using System.Collections.Generic;
using System;

namespace ArrangeActAssert.Context
{
    public sealed class DefaultContext  : IContext
    {
        Dictionary<string, (object, Type)> _parameters = new Dictionary<string, (object, Type)>();

        public DefaultContext()
        {
        }

        public void Add<T>(string name, T value)
        {
            _parameters.Add(name, (value, typeof(T)));
        }

        public T Get<T>(string name)
        {
            if (_parameters.ContainsKey(name) == false)
            {
                throw new ArgumentException($"{name} not found");
            }

            (object value, Type type) = _parameters[name];
            if (type != typeof(T))
            {
                throw new InvalidCastException($"Store parameter type {type} doesn't match to generic type {typeof(T)}");
            }

            return (T)value;
        }

        public T GetSystemUnderTest<T>() => Get<T>("SUT");

        public void SetSystemUnderTest<T>(T systemUnderTest)
        {
            Add<T>("SUT", systemUnderTest);
        }
    }
}