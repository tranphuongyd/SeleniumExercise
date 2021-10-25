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
    class SearchBookTests
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
        public void TC01_SearchLowerCase()
        {
            var homePage = new HomePage(_driver);
            homePage.CloseAds();
            homePage.GotoBooksPage();

            var bookStorePage = new BookStorePage(_driver);
            var result = bookStorePage.Search("design");

            Assert.IsTrue(result.Count() > 0);
            Assert.IsTrue(result.FirstOrDefault(x => x.Text == "Learning JavaScript Design Patterns" || x.Text == "“Designing Evolvable Web APIs with ASP.NET") != null);
        }
        [Test]
        public void TC02_SearchUpperCase()
        {
            var homePage = new HomePage(_driver);
            homePage.CloseAds();
            homePage.GotoBooksPage();

            var bookStorePage = new BookStorePage(_driver);
            var result = bookStorePage.Search("DESIGN");

            Assert.IsTrue(result.Count() > 0);
            Assert.IsTrue(result.FirstOrDefault(x => x.Text == "Learning JavaScript Design Patterns" || x.Text == "“Designing Evolvable Web APIs with ASP.NET") != null);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
