using HomeworkSeleniumExercise.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.PageObjects
{
    public class BookPage : BasePage
    {
        IWebDriver _driver;
        public BookPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void AddToCollection()
        {
            By byAddButton = By.XPath("//button[text() = 'Add To Your Collection']");

            WaitForElementVisible(byAddButton, TimeSpan.FromSeconds(10));

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

            ClickToElement(byAddButton);
            //Thread.Sleep(5000);
        }

        public void CloseAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }
    }
}
