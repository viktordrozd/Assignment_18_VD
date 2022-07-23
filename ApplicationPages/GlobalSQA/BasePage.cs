using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationPages.GlobalSQA
{
    public class BasePage
    {

        protected IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }



    }
}