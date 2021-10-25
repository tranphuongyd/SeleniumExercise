using HomeworkSeleniumExercise.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.PageObjects
{
    public class ProfilePage: BasePage
    {
        IWebDriver _driver;
        public ProfilePage(IWebDriver driver): base(driver)
        {
            _driver = driver;
        }

        public void ScrollToBottom()
        {

        }

        public void GotoStorePage()
        {
            By byGotoStorePage = By.Id("gotoStore");
            WaitForElementVisible(byGotoStorePage, TimeSpan.FromSeconds(10));
            ClickToElement(byGotoStorePage);
        }
        
        public bool CheckBookAdded(string bookName)
        {
            By byItemName = By.LinkText(bookName);
            WaitForElementVisible(byItemName, TimeSpan.FromSeconds(10));
            return _driver.FindElement(byItemName).Displayed;
        }

        public void RemoveBookFromList(string bookName)
        {
            By byRemove = By.XPath("//a[text()='"+ bookName + "']/ancestor::div[@class='rt-td']/following-sibling::div//span[@title='Delete']");
            ClickToElement(byRemove);
            By byConfirmation = By.Id("closeSmallModal-ok");
            ClickToElement(byConfirmation);
            Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Accept();
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
