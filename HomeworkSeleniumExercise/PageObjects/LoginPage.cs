using HomeworkSeleniumExercise.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.PageObjects
{
    public class LoginPage : BasePage
    {
        IWebDriver _driver;
        public LoginPage(IWebDriver driver): base(driver)
        {
            _driver = driver;
        }

        public void LoginWithValidUser(string username, string password)
        {
            By byUsername = By.Id("userName");
            By byPassword = By.Id("password");
            By byLoginButton = By.Id("login");
            SendKeysToElement(byUsername, username);
            SendKeysToElement(byPassword, password);
            ClickToElement(byLoginButton);
        }
    }
}
