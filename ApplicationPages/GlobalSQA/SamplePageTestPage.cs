using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationPages.GlobalSQA
{
    public class SamplePageTestPage : BasePage
    {
        public SamplePageTestPage(IWebDriver driver) : base(driver) { }

        private IWebElement _profilePicInput => _driver.FindElement(By.CssSelector("[name='file-553']"));
        private IWebElement _experienceDropdown => _driver.FindElement(By.CssSelector("#g2599-experienceinyears"));
        private List<IWebElement> _checkboxes => _driver.FindElements(By.CssSelector("input.checkbox-multiple")).ToList();
        private List<IWebElement> _radioButtons => _driver.FindElements(By.CssSelector("input.radio")).ToList();
        private IWebElement commentTextArea => _driver.FindElement(By.CssSelector("#contact-form-comment-g2599-comment"));
        private IWebElement submitButton => _driver.FindElement(By.CssSelector("button.pushbutton-wide"));




    }
}
