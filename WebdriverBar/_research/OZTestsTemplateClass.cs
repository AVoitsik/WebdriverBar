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
    // [TestClass]
    public class OZTestsTemplateClass
    {
        public static IWebDriver driver;
        //public static IWebDriver driverSec;

        [TestMethod]
        [Ignore]
        public void OZTestsTemplate()
        {
            driver.FindElement(By.ClassName("top-panel__userbar__auth")).Click();
            

            driver.FindElement(By.Id("loginFormLoginEmailLink")).Click();
            driver.FindElement(By.Name("cl_email")).SendKeys("kotov2003@yahoo.com");
            driver.FindElement(By.Name("cl_psw")).SendKeys("529zM3");
            driver.FindElement(By.Name("cl_psw")).Submit();

            driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner")).Click();
            driver.FindElement(By.LinkText("Выйти")).Click();

            #region MyRegion
            //driverSec.FindElement(By.Name("q")).SendKeys("marrysav");
            //driverSec.FindElement(By.Name("q")).Submit();
            //top-panel__userbar__user__name__inner        
            //driverSec.FindElement(By.Name("q")).Submit();
            //top-panel__userbar__user__name__inner 
            #endregion
        }

        [TestInitialize]
        public void Initialize()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");

          

            driver = new ChromeDriver(opt);
            driver.Navigate().GoToUrl("https://oz.by/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            #region MyRegion
            //ChromeOptions opt2 = new ChromeOptions();
            //opt2.AddArguments(@"user-data-dir=C:\ChromeProfile2", "start-maximized");
            //driverSec = new ChromeDriver(opt2);
            //driverSec.Navigate().GoToUrl("http://www.google.com"); 
            #endregion

        }

        [TestCleanup]
        public void Cleaup()
        {
            driver.Quit();
            driver = null;
            //driverSec.Quit();
            //driverSec = null;
        }
    }
}
