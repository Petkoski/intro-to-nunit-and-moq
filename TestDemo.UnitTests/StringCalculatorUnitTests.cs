using NUnit.Framework;

namespace TestDemo.UnitTests
{
    [TestFixture]
    public class StringCalculatorUnitTests
    {
        //[Test]
        //public void UnitUnderTest_Scenario_ExpectedOutcome()
        //{

        //}

        [Test]
        public void Add_EmptyString_Returns0()
        {
            StringCalculator calc = new StringCalculator();
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
            StringCalculator calc = new StringCalculator();
            int result = calc.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("2,3", 5)]
        [TestCase("101,20", 121)]
        [TestCase("3,8, 10", 21)]
        [TestCase("-2,-3", -5)]
        public void Add_MultipleNumbers_ReturnsSumOfAllNumbers(string input, int expectedResult)
        {
            StringCalculator calc = new StringCalculator();
            int result = calc.Add(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}