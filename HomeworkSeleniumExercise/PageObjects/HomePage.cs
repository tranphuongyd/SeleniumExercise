using HomeworkSeleniumExercise.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.PageObjects
{
    class HomePage: BasePage
    {
        IWebDriver _driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void CloseAds()
        {
            By byAdsButton = By.Id("close-fixedban");
            ClickToElement(byAdsButton);
        }

        public void GotoBooksPage()
        {
            By byGotoBookPage = By.CssSelector(".card.mt-4.top-card:nth-of-type(6)");
            ClickToElement(byGotoBookPage);
        }

        public void GotoLoginPage()
        {
            By byLoginButton = By.Id("login");
            ClickToElement(byLoginButton);
        }
    }
}
