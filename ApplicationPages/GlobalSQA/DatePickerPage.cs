using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ApplicationPages.GlobalSQA
{
    public class DatePickerPage : BasePage
    {
        public DatePickerPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement dataPickerFrame => _driver.FindElement(By.CssSelector(".demo-frame.lazyloaded"));
        private IWebElement _dateField => _driver.FindElement(By.CssSelector("#datepicker"));
        private IWebElement _datePickerTitle => _driver.FindElement(By.CssSelector(".ui-datepicker-title"));
        private IWebElement _previousMonth => _driver.FindElement(By.CssSelector("[data-handler='prev']"));
        private IWebElement _nextMonth => _driver.FindElement(By.CssSelector("[data-handler='next']"));
        private IWebElement _month => _driver.FindElement(By.CssSelector(".ui-datepicker-month"));
        private IWebElement _year => _driver.FindElement(By.CssSelector(".ui-datepicker-year"));
        private List<IWebElement> _days => _driver.FindElements(By.CssSelector("[data-handler='selectDay']")).ToList();

        public void SetCurrentDateInNextMonth()
        {
            // I've decided use an easy way :). I know the limitations.
            var dateToSet = DateTime.Today.AddMonths(1).ToShortDateString();
            _dateField.Click();
            SetDate(dateToSet);
        }


        public void SetDate(string date)
        {
            _dateField.Click();
            SetMonth(date);
            SetDay(date);
        }

        private void SetMonth(string date)
        {
            DateTime dateToSet = DateTime.Parse(date);
            DateTime monthYearCurrent = DateTime.Parse(_datePickerTitle.GetAttribute("textContent"));


            while (dateToSet.Year < monthYearCurrent.Year)
            {
                _previousMonth.Click();
                monthYearCurrent = DateTime.Parse(_datePickerTitle.GetAttribute("textContent"));
            }

            while (dateToSet.Year > monthYearCurrent.Year)
            {
                _nextMonth.Click();
                monthYearCurrent = DateTime.Parse(_datePickerTitle.GetAttribute("textContent"));
            }

            while (dateToSet.Month < monthYearCurrent.Month)
            {
                _previousMonth.Click();
                monthYearCurrent = DateTime.Parse(_datePickerTitle.GetAttribute("textContent"));
            }

            while (dateToSet.Month > monthYearCurrent.Month)
            {
                _nextMonth.Click();
                monthYearCurrent = DateTime.Parse(_datePickerTitle.GetAttribute("textContent"));
            }

        }

        private void SetDay(string date)
        {
            DateTime dateToSet = DateTime.Parse(date);

            var dayToSet = from day in _days
                           where day.GetAttribute("textContent").ToString() == dateToSet.Day.ToString()
                           select day;
            dayToSet.First().Click();
        }

        public bool CheckDateFormat(string date, string format)
        {
            DateTime dateTime;

            if(DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetCurrentDateFromDatePicker()
        {
            return _dateField.GetAttribute("value");
        }
    }
}
