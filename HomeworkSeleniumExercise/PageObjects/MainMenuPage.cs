using HomeworkSeleniumExercise.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.PageObjects
{
    public class MainMenuPage: BasePage
    {
        IWebDriver _driver;
        public MainMenuPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void OpenBooksPage()
        {
            By byProfilePage = By.XPath("//span[text()='Book Store']/parent::li");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            ClickToElement(byProfilePage);
        }

        public void OpenProfilePage()
        {
            By byProfilePage = By.XPath("//span[text()='Profile']/parent::li");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            ClickToElement(byProfilePage);
        }
    }
}
