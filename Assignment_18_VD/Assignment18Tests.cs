using NUnit.Framework;
using ApplicationPages.GlobalSQA;
using Assignment_18_VD;

namespace Assignment_16_VD
{
    public class Assignment18Tests : BaseTest
    {
        [Test]
        [Category("Selenium")]
        public void Assignment18_1Test()
        {
            string globalSqaUrl = "https://www.globalsqa.com/";
            string menuFirstLevel = "Tester’s Hub";
            string menuSecondLevel = "Sample Page Test";



            driver.Url = globalSqaUrl;
            HomePage homePage = new HomePage(driver);

            homePage.menu.navigateTo(menuFirstLevel, menuSecondLevel);

            SamplePageTestPage samplePageTestPage = new SamplePageTestPage(driver);


        }
    }
}