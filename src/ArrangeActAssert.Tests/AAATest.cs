using NUnit.Framework;

namespace ArrangeActAssert.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1() =>
            Pattern.New.Arrange(
                ctx =>
                {
                    int a = 1;
                    ctx.Add(nameof(a), a);
                }
                )
                .Act(
                ctx => 
                {
                    ctx.Add("a", ctx.Get<int>("a") + 1);
                }
                )
                .Assert(
                ctx => 
                {
                    int a = ctx.Get<int>("a");
                    NUnit.Framework.Assert.AreEqual(2, a);
                }
                )
                .Invoke();
    }
}