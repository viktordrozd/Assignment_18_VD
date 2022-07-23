using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using ApplicationPages.GlobalSQA;

using System.Threading;

namespace Assignment_16_VD
{
    public class Assignment18Tests
    {


        [Test]
        [Category("Selenium")]
        public void Assignment16_1Test()
        {
            string globalSqaUrl = "https://www.globalsqa.com/";
            string menuFirstLevel = "Tester’s Hub";
            string menuSecondLevel = "Demo Testing Site";
            string menuThirdLevel = "DatePicker";
            string format = "MM/dd/yyyy";


            driver.Url = globalSqaUrl;
            //Thread.Sleep(1000);
            HomePage homePage = new HomePage(driver);

            homePage.menu.navigateTo(menuFirstLevel, menuSecondLevel, menuThirdLevel);

            DatePickerPage datePickerPage = new DatePickerPage(driver);
            driver.SwitchTo().Frame(datePickerPage.dataPickerFrame);

            datePickerPage.SetCurrentDateInNextMonth();

            Assert.True(datePickerPage.CheckDateFormat(datePickerPage.GetCurrentDateFromDatePicker(), format), $"Date Format is differ from expected: MM/dd/yyyy");
        }

        [Test]
        [Category("Selenium")]
        public void Assignment16_2Test()
        {
            string globalSqaUrl = "https://www.globalsqa.com/";
            string menuFirstLevel = "Tester’s Hub";
            string menuSecondLevel = "Demo Testing Site";
            int expectedCount = 6;


            driver.Url = globalSqaUrl;
            //Thread.Sleep(1000);
            HomePage homePage = new HomePage(driver);

            homePage.menu.navigateTo(menuFirstLevel, menuSecondLevel);
            DemoTestingSitePage demoTestingSitePage = new DemoTestingSitePage(driver);
            //Thread.Sleep(2000);
            Assert.True(demoTestingSitePage.VerifyItemsCountInColumns(expectedCount),$"Expected {expectedCount} for all columns, but that was not true" );

        }
        [Test]
        [Category("Selenium")]
        public void Assignment16_3Test()
        {
            string globalSqaUrl = "https://www.globalsqa.com/";
            string menuFirstLevel = "Tester’s Hub";
            string menuSecondLevel = "Demo Testing Site";
            string menuThirdLevel = "Progress Bar";


            driver.Url = globalSqaUrl;
            //Thread.Sleep(1000);
            HomePage homePage = new HomePage(driver);

            homePage.menu.navigateTo(menuFirstLevel, menuSecondLevel, menuThirdLevel);
            ProgressBarPage progressBarPage = new ProgressBarPage(driver);
            //Thread.Sleep(2000);
            driver.SwitchTo().Frame(progressBarPage.progressBarFrame);
            progressBarPage.StartDownload();
            Assert.True(progressBarPage.IsDownloadComplete(driver), "Download didn't complete!");

        }


        IWebDriver driver;

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