using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Context
{
    public interface IContext
    {
        void Add<T>(string v, T a);
        T Get<T>(string v);
    }
}
