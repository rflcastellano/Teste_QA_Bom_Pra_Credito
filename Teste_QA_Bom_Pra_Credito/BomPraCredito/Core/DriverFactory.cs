using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomPraCredito.Core
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        private DriverFactory() { }

        private static Actions action;

        public static IWebDriver getDriver()
        {
            if (driver == null)
            {
                switch (Propriedades.browser)
                {
                    case Propriedades.Browsers.FIREFOX:
                        driver = new FirefoxDriver();
                        break;

                    default:
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return driver;
        }

        public static void IniciaNavegador(string http)
        {
            getDriver().Navigate().GoToUrl(http);
            action = new Actions(driver);
        }

        public static void KillDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
