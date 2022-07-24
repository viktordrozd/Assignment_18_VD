using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;


namespace ApplicationPages.Components
{
    public class Menu
    {
        private IWebDriver _driver;
        public Menu(IWebDriver driver)
        {
            _driver = driver;
        }

        public void navigateTo(string firstLevel)
        {
            Actions actions = new Actions(_driver);
            actions
                .MoveToElement(getMenuItem(firstLevel))
                .Click()
                .Perform();
        }

        public void navigateTo(string firstLevel, string secondLevel)
        {
            Actions actions = new Actions(_driver);
            actions
                .MoveToElement(getMenuItem(firstLevel))
                .MoveToElement(getMenuItem(secondLevel))
                .Click()
                .Perform();
        }

        public void navigateTo(string firstLevel, string secondLevel, string thirdLevel)
        {
            Actions actions = new Actions(_driver);
            actions
                .MoveToElement(getMenuItem(firstLevel))
                .MoveToElement(getMenuItem(secondLevel))
                .MoveToElement(getMenuItem(thirdLevel))
                .Click()
                .Perform();
        }

        private IWebElement getMenuItem(string menuItemName)
        {
            List<IWebElement> menuItems = _driver.FindElements(By.CssSelector(".menu-item a")).ToList();

            var menuItem = from item in menuItems
                           where item.GetAttribute("textContent").ToString() == menuItemName
                           select item;
            return menuItem.First();
        }
    }
}
