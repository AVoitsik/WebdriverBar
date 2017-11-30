using System;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace WebdriverBar
{
    [TestClass]
    public class OzCookiesClass
    {
        public static IWebDriver driver;
        //public static IWebDriver driverSec;

        [TestMethod]
        public void OzCookies()
        {
            driver.FindElement(By.ClassName("top-panel__userbar__auth")).Click();


            driver.FindElement(By.Id("loginFormLoginEmailLink")).Click();
            driver.FindElement(By.Name("cl_email")).SendKeys("kotov2003@yahoo.com");
            driver.FindElement(By.Name("cl_psw")).SendKeys("529zM3");
            driver.FindElement(By.Name("cl_psw")).Submit();

           ReadOnlyCollection<Cookie> collection =  driver.Manage().Cookies.AllCookies;
            foreach (var cookie in collection)
            {
                LogMessageToFile("Cooks",(cookie.Name + "=" + cookie.Value));
            }

            //driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner")).Click();
            //driver.FindElement(By.LinkText("Выйти")).Click();

        }

        public void LogMessageToFile(string fileName, string msg)
        {

            string datePartName = System.String.Format(
                "{0:yyyy-MM-dd_hh-mm-ss-tt}",DateTime.Now);
            string fullFileName = @"C:\Temp\" + datePartName + fileName + ".txt";
                System.IO.StreamWriter sw = System.IO.File.AppendText(fullFileName);
                try
                {
                    string logLine = System.String.Format(
                        "{0:G}: {1}.", System.DateTime.Now, msg);
                    sw.WriteLine(logLine);
                }
                finally
                {
                    sw.Close();
                }
            
        }

        [TestInitialize]
        public void Initialize()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");



            driver = new ChromeDriver(opt);
            driver.Navigate().GoToUrl("https://oz.by/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


        }

        [TestCleanup]
        public void Cleaup()
        {
            driver.Close();
            driver.Quit();
            driver = null;

        }
    }
}
