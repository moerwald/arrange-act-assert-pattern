using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Context
{
    public interface IContext
    {
        void Add<T>(string name, T value);
        T Get<T>(string name);
        void SetSystemUnderTest<T>(T systemUnderTest);
        T GetSystemUnderTest<T>();
    }
}
