using Moq;
using NUnit.Framework;

namespace TestDemo.UnitTests
{
    [TestFixture]
    public class FooControllerUnitTests
    {
        //private Mock<IFoo> _fooMock;

        //private FooController GetFoo()
        //{
        //    _fooMock = new Mock<IFoo>();
        //    return new FooController(_fooMock.Object);
        //}

        [Test]
        public void DoSomething_AnyString_ReturnsTrue()
        {
            var mockFoo = new Mock<IFoo>();
            mockFoo.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);

            FooController fc = new FooController(mockFoo.Object);

            Assert.That(fc.DoSomething("ping"), Is.True);
        }

        //Out arguments
        [Test]
        public void TryParse_AnyString_ReturnsTrueAndOutsAck()
        {
            var mockFoo = new Mock<IFoo>();
            var outString = "ack";
            mockFoo.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            FooController fc = new FooController(mockFoo.Object);
            var resultString = "";

            Assert.Multiple(() =>
            {
                Assert.That(fc.TryParse("ping", out resultString), Is.True);
                Assert.That(resultString, Is.EqualTo("ack"));
            });
        }
    }
}
