using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Assignment_18_VD
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1400,1000");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        [TearDown]
        public void AfterTests()
        {
            driver.Quit();
        }
    }
}
