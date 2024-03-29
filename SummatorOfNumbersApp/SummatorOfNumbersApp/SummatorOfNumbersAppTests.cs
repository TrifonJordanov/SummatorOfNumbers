using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace SummatorOfNumbersApp
{
    public class SummatorOfNumbersAppTests
    {
        private SumattorApp driver;

        [OneTimeSetUp]
        public void Open()
        {
            driver = new SumattorApp();
            driver.Open();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithPositiveNumbers()
        {
            var actual = driver.SumNums("3", "3");
            Assert.AreEqual("Sum: 6", actual);
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithNegative()
        {
            var actual = driver.SumNums("-1", "-1");
            var expected = "Sum: -2";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithZero()
        {
            var actual = driver.SumNums("0", "0");
            var expected = "Sum: 0";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithFirstSymbolDigit()
        {
            var actual = driver.SumNums("1@", "0!!!");
            var expected = "Sum: 1";
            Assert.AreEqual(expected, actual);
        }

        [TestCase("asd", "dsa")]
        [TestCase("@@", "!!!!")]
        [TestCase("@2@", "!!2!!")]
        public void ValidateSumMethod_ThrowExceptionWithInvalidData(string first, string second)
        {
            var actual = driver.SumNums(first, second);
            var expected = "Sum: invalid input";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidateSummator_TitlePresent()
        {
            Assert.AreEqual("Sum Two Numbers", driver.PageTitle);
        }

        [Test]
        public void ValidateSummator_HeadingPresent()
        {
            Assert.AreEqual("Sum Two Numbers", driver.PageTitle);
        }
    }
}