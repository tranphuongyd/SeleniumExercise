using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace HomeworkSeleniumExercise.Common
{
    public class BasePage
    {
        IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickToElement(By locator)
        {
            _driver.FindElement(locator).Click();
        }

        public IEnumerable<IWebElement> GetElements(By locator)
        {
            return _driver.FindElements(locator);
        }

        public void SendKeysToElement(By locator, string value)
        {
            var element = _driver.FindElement(locator);
            element.Clear();
            element.SendKeys(value);
        }

        public void WaitForElementVisible(By locator, TimeSpan time)
        {
            WebDriverWait explicitWait = new WebDriverWait(_driver, time);
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementInvisible(By locator, TimeSpan time)
        {
            WebDriverWait explicitWait = new WebDriverWait(_driver, time);
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }


        public void WaitForElementClickable(By locator, TimeSpan time)
        {
            WebDriverWait explicitWait = new WebDriverWait(_driver, time);
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitForAlertClickable(TimeSpan time)
        {
            WebDriverWait explicitWait = new WebDriverWait(_driver, time);
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
    }
}
