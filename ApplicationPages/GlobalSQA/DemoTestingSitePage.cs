using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationPages.GlobalSQA
{
    public class DemoTestingSitePage : BasePage
    {
        public DemoTestingSitePage(IWebDriver driver) : base(driver)
        {

        }

        private List<IWebElement> _columns => _driver.FindElements(By.CssSelector("[class='price_column ']")).ToList();

        public bool VerifyItemsCountInColumns(int count)
        {
            List<int> itemsCount = GetItemsCount();
            return itemsCount.All(i => i.Equals(count));

        }

        private List<int> GetItemsCount()
        {
            List<int> itemCounts = new List<int>();
            foreach (var item in _columns)
            {
                itemCounts.Add(item.FindElements(By.CssSelector("[class='price_footer']")).Count());
            }
            return itemCounts;
        }



    }
}
