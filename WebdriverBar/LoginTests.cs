using System;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OzFramework;
using OpenQA.Selenium.Support;

namespace OzTests
{
    [TestClass]
    public class LoginTests:TestBase
    {
        //public  IWebDriver driver;


        [TestMethod]
        public void LoginWithPwdTest()
        {
            app.LoginWithPwd();
            //LoginPage.GoTo();
            //LoginPage.LoginAs("kotov2003@yahoo.com").WithPassword("529zM3").Login();
            //Assert.IsTrue(MainPage.IsAt, "Faild to Login");
            
            ////CreateCookiesLog(); 
            app.Exit();
            //MainPage.Exit();
        }


        [TestMethod]
        public void LoginWithPhoneTest()
        {
            app.LoginWithPhone();
            //LoginPage.GoTo();
            //LoginPage.LoginAs("").WithPhone("297033721").GetSMS();
            //LoginPage.Close();
            ////Add exit           
        }

        [TestMethod]
        public void CheckOrdersTest()
        {
            app.LoginWithPwd();
            //LoginPage.GoTo();
            //LoginPage.LoginAs("kotov2003@yahoo.com").WithPassword("529zM3").Login();
            //Assert.IsTrue(MainPage.IsAt, "Faild to Login");
            ////MainPage.GoToOrders();
            app.CheckPopupList();
            //MainPage.checkPopupList();
            app.Exit();
            //MainPage.Exit();
            //CreateCookiesLog();            
        }


    }
}
