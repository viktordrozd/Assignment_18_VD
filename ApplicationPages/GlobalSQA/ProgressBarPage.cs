using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ApplicationPages.GlobalSQA
{
    public class ProgressBarPage : BasePage
    {
        public ProgressBarPage(IWebDriver driver) : base(driver) { }

        public IWebElement progressBarFrame => _driver.FindElement(By.CssSelector(".demo-frame.lazyloaded"));

        private IWebElement _downloadButton => _driver.FindElement(By.CssSelector("#downloadButton"));

        private IWebElement _progressMessage => _driver.FindElement(By.CssSelector(".progress-label"));


        public void StartDownload()
        {
            _downloadButton.Click();
        }

        bool IsCompleteMessageShown(IWebDriver driver)
        {

            if (_progressMessage.GetAttribute("textContent") == "Complete!")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsDownloadComplete(IWebDriver driver)
        {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        wait.Until(IsCompleteMessageShown);

            if (_progressMessage.GetAttribute("textContent") == "Complete!")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
