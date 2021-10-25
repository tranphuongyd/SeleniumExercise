using HomeworkSeleniumExercise.Common;
using HomeworkSeleniumExercise.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.TestCases
{
    [TestFixture]
    class RemoveBookTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var helper = new Helpers();
            _driver = helper.CreateWebDriver(Settings.BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com");
        }
        [Test]
        public void TC01_RemoveBook()
        {
            string bookName = "Git Pocket Guide";
            var homePage = new HomePage(_driver);
            homePage.CloseAds();
            homePage.GotoBooksPage();

            var bookStorePage = new BookStorePage(_driver);
            bookStorePage.GotoLoginPage();

            var loginPage = new LoginPage(_driver);
            loginPage.LoginWithValidUser(Constants.VALID_USERNAME, Constants.VALID_PASSWORD);

            bookStorePage.SelectItem(bookName);
            homePage.CloseAds();

            var bookPage = new BookPage(_driver);
            bookPage.AddToCollection();

            bookPage.WaitForAlertClickable(TimeSpan.FromSeconds(5));

            bookPage.CloseAlert();

            var menuPage = new MainMenuPage(_driver);
            menuPage.OpenProfilePage();

            var profilePage = new ProfilePage(_driver);
            var result = profilePage.Search(bookName);

            Assert.IsTrue(result.Count() > 0);
            profilePage.RemoveBookFromList(bookName);

            result = profilePage.Search(bookName);
            Assert.IsTrue(result.Count() == 0);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
