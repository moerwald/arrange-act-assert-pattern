using ArrangeActAssert.Context;
using NUnit.Framework;
using System;

namespace ArrangeActAssert.Tests.Context
{
    [TestFixture]
    public sealed class DefaultContextTests
    {
        [Test]
        public void Add_InputIsValid_DontThrowException()
        {
            var ctx = new DefaultContext();
            Assert.DoesNotThrow(() => ctx.Add("someName", 1));
        }

        [Test]
        public void Get_ParmeterNotFound_ThrowInvalidArgumentException()
        {
            var ctx = new DefaultContext();
            Assert.Throws<ArgumentException>(
                () => ctx.Get<int>("invalidName")
                );
        }

        [Test]
        public void Get_TypeDoesntMatchStoreOne_ThrowInvalidCastException()
        {
            var ctx = new DefaultContext();
            ctx.Add("a", 1);
            Assert.Throws<InvalidCastException>(
                () => ctx.Get<string>("a")
                );
        }

        [Test]
        public void Get_TypeMatchesStoredOne_CorrectValueIsReturned()
        {
            var ctx = new DefaultContext();
            ctx.Add("a", 1);
            Assert.AreEqual(1, ctx.Get<int>("a"));
        }

        [Test]
        public void GetSystemUnderTest_SutWasSetBeforehand_CorrectValueIsReturned()
        {
            var ctx = new DefaultContext();
            ctx.SetSystemUnderTest("System under Test");
            Assert.AreEqual("System under Test", ctx.GetSystemUnderTest<string>());
        }
    }
}
