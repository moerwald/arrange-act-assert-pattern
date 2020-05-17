using ArrangeActAssert.Context;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Tests.Context
{
    [TestFixture]
    public class DefaultContextTests
    {
        [Test]
        public void Add_InputIsValid_DontThrowException()
        {
            var ctx = new DefaultContext();
            Assert.DoesNotThrow(() => ctx.Add("someName", 1));
        }

        [Test]
        public void Get_ParmeterNotFound_InvalidArgumentException()
        {
            var ctx = new DefaultContext();
        }
    }
}
