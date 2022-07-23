using ApplicationPages.Components;
using OpenQA.Selenium;

namespace ApplicationPages.GlobalSQA
{
    public class HomePage : BasePage
    {
        public Menu menu;

        public HomePage(IWebDriver driver) : base(driver) 
        {
            menu = new Menu(driver);
        }

    }
}
