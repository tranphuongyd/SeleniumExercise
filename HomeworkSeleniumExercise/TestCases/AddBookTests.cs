using HomeworkSeleniumExercise.Common;
using HomeworkSeleniumExercise.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkSeleniumExercise.TestCases
{
    [TestFixture]
    class AddBookTests
    {
        IWebDriver _driver;
        string _bookName = "Git Pocket Guide";

        [SetUp]
        public void Setup()
        {
            var helper = new Helpers();
            _driver = helper.CreateWebDriver(Settings.BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com");
        }

        [Test]
        public void TC01_AddBookToCollection()
        {
            var homePage = new HomePage(_driver);
            homePage.CloseAds();
            homePage.GotoBooksPage();

            var bookStorePage = new BookStorePage(_driver);
            bookStorePage.GotoLoginPage();

            var loginPage = new LoginPage(_driver);
            loginPage.LoginWithValidUser(Constants.VALID_USERNAME, Constants.VALID_PASSWORD);

            bookStorePage.SelectItem(_bookName);

            homePage.CloseAds();

            var bookPage = new BookPage(_driver);
            bookPage.AddToCollection();

            bookPage.WaitForAlertClickable(TimeSpan.FromSeconds(5));

            var profilePage = new ProfilePage(_driver);

            var menuPage = new MainMenuPage(_driver);
            if (_driver.SwitchTo().Alert().Text == "Book already present in the your collection!")
            {
                bookPage.CloseAlert();
                menuPage.OpenProfilePage();
                
                Thread.Sleep(5000);

                profilePage.RemoveBookFromList(_bookName);

                menuPage.OpenBooksPage();
                bookStorePage.SelectItem(_bookName);

                bookPage.AddToCollection();
                bookPage.WaitForAlertClickable(TimeSpan.FromSeconds(5));
            }

            bookPage.CloseAlert();

            menuPage.OpenProfilePage();

            Assert.True(profilePage.CheckBookAdded(_bookName));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
