using HomeworkSeleniumExercise.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.PageObjects
{
    public class BookStorePage : BasePage
    {
        IWebDriver _driver;
        public BookStorePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void SelectItem(string itemName)
        {
            By byItemName = By.LinkText(itemName);
            WaitForElementVisible(byItemName, TimeSpan.FromSeconds(10));
            ClickToElement(byItemName);
        }

        public void GotoLoginPage()
        {
            By byLoginButton = By.Id("login");
            WaitForElementVisible(byLoginButton, TimeSpan.FromSeconds(10));
            ClickToElement(byLoginButton);
        }

        public IEnumerable<IWebElement> Search(string keyword)
        {
            By bySearchTextBox = By.Id("searchBox");
            WaitForElementVisible(bySearchTextBox, TimeSpan.FromSeconds(3));
            SendKeysToElement(bySearchTextBox, keyword);

            By byResult = By.XPath("//span[starts-with(@id, 'see-book')]/a");
            var result = GetElements(byResult);
            return result;
        }

        
    }
}
