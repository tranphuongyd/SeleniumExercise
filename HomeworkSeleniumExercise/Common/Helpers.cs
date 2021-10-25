using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeworkSeleniumExercise.Common.Settings;

namespace HomeworkSeleniumExercise.Common
{
    public class Helpers
    {
        public IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                    break;
                case BrowserType.FireFox:
                    return new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                    return new EdgeDriver();
                    break;
                default:
                    return new ChromeDriver();
                    break;
            }
        }
    }
}
