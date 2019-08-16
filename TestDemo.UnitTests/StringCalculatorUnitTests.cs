using Moq;
using NUnit.Framework;
using System;

namespace TestDemo.UnitTests
{
    [TestFixture]
    public class StringCalculatorUnitTests
    {
        private Mock<IStore> _mockStore;

        //[Test]
        //public void UnitUnderTest_Scenario_ExpectedOutcome()
        //{

        //}

        private StringCalculator GetCalculator()
        {
            _mockStore = new Mock<IStore>();
            return new StringCalculator(_mockStore.Object); //.Object - how we would refer to a mock of some interface
        }

        [Test]
        public void Add_EmptyString_Returns0()
        {
            StringCalculator calc = GetCalculator();
            int expectedResult = 0;
            int result = calc.Add("");
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("33", 33)]
        public void Add_SingleNumbers_ReturnsTheNumber(string input, int expectedResult)
        {
            StringCalculator calc = GetCalculator();
            int result = calc.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("2,3", 5)]
        [TestCase("101,20", 121)]
        [TestCase("3,8, 10", 21)]
        [TestCase("0,-3", -3)]
        [TestCase("-2,-3", -5)]
        [TestCase("-1,5", 4)]
        public void Add_MultipleNumbers_ReturnsSumOfAllNumbers(string input, int expectedResult)
        {
            StringCalculator calc = GetCalculator();
            int result = calc.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("a,1")]
        [TestCase("abc,''")]
        [TestCase("qwerty")]
        [TestCase("-,/")]
        public void Add_InvalidString_ThrowsException(string input)
        {
            StringCalculator calc = GetCalculator();
            Assert.That(() => calc.Add(input), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        [TestCase("2")]                         //2
        [TestCase("5,6")]                       //11
        [TestCase("3,4")]                       //7
        [TestCase("10, 10, 3")]                 //23
        [TestCase("5,5,5,5,5,5,5,5,5,5,3")]     //53
        public void Add_ResultIsAPrimeNumber_ResultIsSaved(string input)
        {
            //Business requirement: If the result is prime - save it
            //Still not sure how saving is going to work

            StringCalculator calc = GetCalculator();
            var result = calc.Add(input);
            //mockStore.Verify(m => m.Save(), Times.Once); //Save expects int parameter
            _mockStore.Verify(m => m.Save(It.IsAny<int>()), Times.Once); //Verifying that Save() is called (with int passed to it)
        }

        [Test]
        [TestCase("4")]                         //4
        [TestCase("5,5")]                       //10
        [TestCase("5,4")]                       //9
        [TestCase("10, 10, 5")]                 //25
        [TestCase("5,5,5,5,5,5,5,5,5,5,1")]     //51
        public void Add_ResultIsNotAPrimeNumber_ResultIsNotSaved(string input)
        {
            StringCalculator calc = GetCalculator();
            var result = calc.Add(input);
            _mockStore.Verify(m => m.Save(It.IsAny<int>()), Times.Never);
        }
    }
}