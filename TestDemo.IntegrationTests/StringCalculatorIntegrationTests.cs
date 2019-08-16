using NUnit.Framework;
using System.IO;
using System.Linq;

/**
 * Example: Client specifies how they want their results to be saved (in the case of prime numbers) - to text files on disk
 * Integration tests - rely on some infrastructure (maybe a web service, database or in this case - file system)
 */

namespace TestDemo.IntegrationTests
{
    [TestFixture]
    public class StringCalculatorIntegrationTests
    {
        private string _filepath = @"E:\CSharp\Training\IntroToNUnitAndMoq\test.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filepath))
                File.Delete(_filepath);
        }

        [Test]
        public void Add_ResultIsPrime_CreatesAFile()
        {
            FileStore store = new FileStore(_filepath);
            StringCalculator calc = new StringCalculator(store);
            var result = calc.Add("3,4");
            Assert.IsTrue(File.Exists(_filepath)); //Testing the existance of the file
        }

        [Test]
        [TestCase("33,4", "37")]
        [TestCase("10,1", "11")]
        public void Add_NumberIsPrime_WritesCorrectResultToFile(string input, string expectedResult)
        {
            FileStore store = new FileStore(_filepath);
            StringCalculator calc = new StringCalculator(store);
            var result = calc.Add(input);

            var storedResult = File.ReadLines(_filepath).FirstOrDefault();

            Assert.That(storedResult, Is.EqualTo(expectedResult));
        }

        [TearDown]
        public void Cleanup()
        {
            Setup();
        }
    }
}