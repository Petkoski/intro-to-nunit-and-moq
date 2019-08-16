using NUnit.Framework;
using System.IO;

/**
 * Example: Client specifies how they want their results to be saved (in the case of prime numbers) - to text files on disk
 * Integration tests - rely on some infrastructure (maybe a web service, database or in this case - file system)
 */

namespace TestDemo.IntegrationTests
{
    [TestFixture]
    public class StringCalculatorIntegrationTests
    {
        [Test]
        public void Add_ResultIsPrime_CreatesAFile()
        {
            string filePath = @"E:\CSharp\Training\IntroToNUnitAndMoq\test.txt";
            FileStore store = new FileStore(filePath);
            StringCalculator calc = new StringCalculator(store);
            var result = calc.Add("3,4");
            Assert.IsTrue(File.Exists(filePath)); //Testing the existance of the file
        }
    }
}