using ArrangeActAssert.Arrange;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Tests.Arrange
{
    [TestFixture]
    public class ArrangeTests
    {
        [Test]
        public void Arrange_ExceptionIsThrown_ExceptionRethrownAsArrangeException()
        {
            NUnit.Framework.Assert.Throws<ArrangeException>(
                () =>
                    Pattern.New
                            .Arrange(c => throw new Exception("Arrange failed"))
                            .Act(x => { })
                            .Assert(x => { })
                            .Invoke()
                            );
        }

    }
}
