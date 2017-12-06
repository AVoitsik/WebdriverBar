using System;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace OzTests
{
    [TestClass]
    public class ChromeTests
    {
        public static IWebDriver driver;
        public static IWebDriver driverSec;
        [TestMethod]
        [Ignore]
        public void MultiBrowser()
        {
            driver.FindElement(By.Name("q")).SendKeys("marrysav");
            driverSec.FindElement(By.Name("q")).SendKeys("marrysav");

            driver.FindElement(By.Name("q")).Submit();
            driverSec.FindElement(By.Name("q")).Submit();

        }

        [TestInitialize]
        public void Initialize()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");

            ChromeOptions opt2 = new ChromeOptions();
            opt2.AddArguments(@"user-data-dir=C:\ChromeProfile2", "start-maximized");

            driver = new ChromeDriver(opt);
            driver.Navigate().GoToUrl("http://www.google.com");

            driverSec = new ChromeDriver(opt2);
            driverSec.Navigate().GoToUrl("http://www.google.com");

        }

        [TestCleanup]
        public void Cleaup()
        {
            driver.Quit();
            driver = null;
            driverSec.Quit();
            driverSec = null;
        }
    }

}
