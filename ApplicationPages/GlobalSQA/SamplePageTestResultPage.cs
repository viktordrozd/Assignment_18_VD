using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationPages.GlobalSQA
{
    public class SamplePageTestResultPage : BasePage
    {
        public SamplePageTestResultPage(IWebDriver driver) : base(driver) { }

        private IWebElement _profilePicInput => _driver.FindElement(By.CssSelector("[name='file-553']"));
        private List<IWebElement> _resultForm => _driver.FindElements(By.CssSelector(".contact-form-submission p")).ToList();


        public string GetProfilePicName()
        {
            return _profilePicInput.GetAttribute("value");
        }

        public Dictionary<string, string> GetResultFormData()
        {
            var result = new Dictionary<string, string>();

            foreach (var item in _resultForm)
            {
                var text = item.GetAttribute("textContent");
                var splitString = text.Split(new String[] { ":", "::" }, StringSplitOptions.RemoveEmptyEntries);

                if (splitString[0] == "Website")
                {
                    result.Add(splitString[0].Trim(), splitString[1].Trim() + ":" + splitString[2].Trim());
                }
                else
                {
                    result.Add(splitString[0].Trim(), splitString[1].Trim());
                }

            }
            return result;
        }


        public string ConvertExpertiseValues(Dictionary<string, bool> values)
        {
            var result = new List<string>();

            foreach (var item in values)
            {
                if (item.Value)
                {
                    result.Add(item.Key);
                }
            }

            string combinedString = string.Join(", ", result);

            return combinedString;
        }
    }
}
