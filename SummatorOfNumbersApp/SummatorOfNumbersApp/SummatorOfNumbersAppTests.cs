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
            var expected = driver.SumNums("3", "3");
            Assert.AreEqual(expected, "Sum: 6");
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithNegative()
        {
            var expected = driver.SumNums("-1", "-1");
            var actual = "Sum: -2";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithZero()
        {
            var expected = driver.SumNums("0", "0");
            var actual = "Sum: 0";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidateSumMethod_SumCorrectlyWithFirstSymbolDigit()
        {
            var expected = driver.SumNums("1@", "0!!!");
            var actual = "Sum: 1";
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