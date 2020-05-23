using ArrangeActAssert.Context;
using NUnit.Framework;
using System;

namespace ArrangeActAssert.Tests.Context
{
    [TestFixture]
    public sealed class DefaultContextTests
    {
        private DefaultContext _ctx;

        [SetUp]
        public  void Setup()
        {
            _ctx = new DefaultContext();
        }

        [Test]
        public void Add_InputIsValid_DontThrowException()
        {
            Assert.DoesNotThrow(() => _ctx.Add("someName", 1));
        }

        [Test]
        public void Add_ParameterAlreadyAdded_ThrowIvalidOperationException()
        {
            _ctx.Add("someName", 1);
            Assert.Throws<ArgumentException>(() => _ctx.Add("someName", 1));
        }

        [Test]
        public void Get_ParmeterNotFound_ThrowInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => _ctx.Get<int>("invalidName")
                );
        }

        [Test]
        public void Get_TypeDoesntMatchStoreOne_ThrowInvalidCastException()
        {
            _ctx.Add("a", 1);
            Assert.Throws<InvalidCastException>(
                () => _ctx.Get<string>("a")
                );
        }

        [Test]
        public void Get_TypeMatchesStoredOne_CorrectValueIsReturned()
        {
            _ctx.Add("a", 1);
            Assert.AreEqual(1, _ctx.Get<int>("a"));
        }

        [Test]
        public void GetSystemUnderTest_SutWasSetBeforehand_CorrectValueIsReturned()
        {
            _ctx.SetSystemUnderTest("System under Test");
            Assert.AreEqual("System under Test", _ctx.GetSystemUnderTest<string>());
        }

        [Test]
        public void GetSystemUnderTest_SutWasNOTSetBeforehand_ThrowInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => _ctx.GetSystemUnderTest<string>()
                );
        }

        [Test]
        public void SetSystemUnderTest_SutWasSetBeforehand_ThrowInvalidOperationException()
        {
            _ctx.SetSystemUnderTest("System under Test");
            Assert.Throws<ArgumentException>(
                () => _ctx.SetSystemUnderTest("Some other System under Test")
                );
        }
    }
}
