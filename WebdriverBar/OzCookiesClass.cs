﻿using System;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OzbyLib;

namespace WebdriverBar
{
    [TestClass]
    public class OzCookiesClass
    {
        public static IWebDriver driver;
        //public static IWebDriver driverSec;

        [TestMethod]
        public void OzLoginPwdTest()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("kotov2003@yahoo.com").WithPassword("529zM3").Login();
            Assert.IsTrue(MainPage.IsAt, "Faild to Login");
            MainPage.Exit();
            //CreateCookiesLog();            
        }

        [TestMethod]
        public void OzLoginTelTest()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPhone("297033721").GetSMS();
            LoginPage.Close();
            //Add exit           
        }

        //private static void Exit()
        //{
        //    driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner")).Click();
        //    driver.FindElement(By.LinkText("Выйти")).Click();
        //}

        private void CreateCookiesLog()
        {
            ReadOnlyCollection<Cookie> collection = driver.Manage().Cookies.AllCookies;
            foreach (var cookie in collection)
            {
                LogMessageToFile("Cooks", (cookie.Name + "=" + cookie.Value));
            }
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
            Driver.Initialize();


        }

        [TestCleanup]
        public void Cleaup()
        {
            Driver.Close();
            //driver.Close();
            //driver.Quit();
            //driver = null;

        }
    }
}
