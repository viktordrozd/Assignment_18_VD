using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationPages.GlobalSQA
{
    public class SamplePageTestPage : BasePage
    {
        public SamplePageTestPage(IWebDriver driver) : base(driver) { }

        private IWebElement _profilePicInput => _driver.FindElement(By.CssSelector("[name='file-553']"));
        private IWebElement _nameInput => _driver.FindElement(By.CssSelector("#g2599-name"));
        private IWebElement _emailInput => _driver.FindElement(By.CssSelector("#g2599-email"));
        private IWebElement _websiteInput => _driver.FindElement(By.CssSelector("#g2599-website"));
        private SelectElement _experienceDropdown => new SelectElement(_driver.FindElement(By.CssSelector("#g2599-experienceinyears")));
        private List<IWebElement> _checkboxes => _driver.FindElements(By.CssSelector("input.checkbox-multiple")).ToList();
        private List<IWebElement> _radioButtons => _driver.FindElements(By.CssSelector("input.radio")).ToList();
        private IWebElement _commentTextArea => _driver.FindElement(By.CssSelector("#contact-form-comment-g2599-comment"));
        private IWebElement _submitButton => _driver.FindElement(By.CssSelector("button.pushbutton-wide"));


        public void UploadProfilePic(string name)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string picPath = "DataFiles" + "\\" + name;
            string fullPath = Path.GetFullPath(Path.Combine(projectPath, picPath));

            _profilePicInput.SendKeys(fullPath);
        }

        public void SetName(string name)
        {
            _nameInput.Clear();
            _nameInput.SendKeys(name);
        }

        public void SetEmail(string email)
        {
            _emailInput.Clear();
            _emailInput.SendKeys(email);
        }

        public void SetWebsite(string website)
        {
            //_websiteInput.Clear();
            //_websiteInput.Click();
            //_websiteInput.SendKeys(website);
            //_websiteInput.SendKeys(Keys.Tab);
            //_websiteInput.SendKeys(Keys.Tab);
            //_websiteInput.Submit();

            //IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            //jse.ExecuteScript($"document.getElementById('g2599-website').value = '{website}'");

            Actions actions = new Actions(_driver);
            actions.MoveToElement(_websiteInput).Click().SendKeys(website).Perform();

            //Thread.Sleep(1000);
        }

        public void SelectExperience(string option)
        {
            _experienceDropdown.SelectByText(option);
        }
        public void SetComment(string comment)
        {
            _websiteInput.Clear();
            _commentTextArea.SendKeys(comment);
        }

        public void SetExperise(Dictionary<string, bool> values)
        {
            foreach (var value in values)
            {
                var checkbox = _driver.FindElement(By.CssSelector($"[value='{value.Key}']"));
                if (value.Value && !checkbox.Selected)
                {
                    checkbox.Click();
                }
                else if (!value.Value && checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }

        public void SetEducation(string option)
        {
            var radioButton = _driver.FindElement(By.CssSelector($"[value='{option}']"));
            radioButton.Click();
        }

        public void SubmitForm()
        {
            _submitButton.Click();
        }

    }
}
