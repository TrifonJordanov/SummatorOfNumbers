using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummatorOfNumbersApp
{
    public class SumattorApp
    {
        private IWebDriver driver;

        public SumattorApp()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public string PageUrl => "https://sum-numbers.nakov.repl.co/";
        public IWebElement PageHeading => driver.FindElement(By.CssSelector("body > form > h1"));
        public string PageTitle => driver.Title;
        public IWebElement NumberOne => driver.FindElement(By.Id("number1"));
        public IWebElement NumberTwo => driver.FindElement(By.Id("number2"));
        public IWebElement CalculateBtn => driver.FindElement(By.Id("calcButton"));
        public IWebElement ResetBtn => driver.FindElement(By.Id("resetButton"));
        public IWebElement Result => driver.FindElement(By.Id("result"));

        public void Open()
        {
            driver.Url = this.PageUrl;
        }

        public void Quit()
        {
            driver.Quit();
        }

        public string SumNums(string first, string second)
        {
            var firstField = this.NumberOne;
            var secondField = this.NumberTwo;
            firstField.Click();
            firstField.SendKeys(first);
            secondField.Click();
            secondField.SendKeys(second);
            this.CalculateBtn.Click();
            var result = this.Result.Text;
            this.ResetBtn.Click();
            return result;
        }
    }
}
