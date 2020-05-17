using ArrangeActAssert.Context;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using NUnitAssert = NUnit.Framework.Assert;

namespace ArrangeActAssert.Tests.Context
{
    [TestFixture]
    public class DefaultContextTests
    {
        [Test]
        public void Add_InputIsValid_DontThrowException()
        {
            var ctx = new DefaultContext();
            NUnitAssert.DoesNotThrow(() => ctx.Add("someName", 1));
        }
    }
}
