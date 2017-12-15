using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{

    public class Application
    {
        private IWebDriver driver;
        private LoginPage LoginPage;
        private MainPage MainPage;
        private OrdersPage OrdersPage;

        public Application()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");
            //driver = new ChromeDriver(options);

            //FirefoxOptions options = new FirefoxOptions();
            //driver = new FirefoxDriver();
            //driver.Manage().Window.Maximize();

            InternetExplorerOptions options = new InternetExplorerOptions();
            driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();


            LoginPage = new LoginPage(driver);
            MainPage = new MainPage(driver);
            OrdersPage = new OrdersPage(driver);
            driver.Navigate().GoToUrl(BaseAddress);
            TurnOffWait();
        }

        private string BaseAddress
        {
            get { return "https://oz.by/"; }
        }

        #region INITIALIZE HIDDEN
        public void Initialize()
        {
            //CHROME
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");
            //options.AddArguments("start-maximized");
            //options.BrowserVersion = "63";
            //options.PlatformName = "Linux";
            //options.PlatformName = "Windows NT"; 
            //options.BinaryLocation = "/opt/google/chrome/google-chrome";//google-chrome
            //Instance = new ChromeDriver(options);

            //FIREFOX
            //FirefoxOptions options = new FirefoxOptions();
            //FirefoxProfile profile = new FirefoxProfile(@"c:\AUTO\WebdriverProfiles\Firefox\");
            ////profile.SetPreference("browser.startup.homepage","https://www.tut.by/");
            //options.Profile = profile;
            //options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            //Instance = new FirefoxDriver(options);
            //Instance.Manage().Window.Maximize();
            ////options.AddArguments(@"--user-data-dir=c:\AUTO\WebdriverProfiles\Firefox\", "--start-maximized");
            ////options.AddArguments(@"user-data-dir=C:\FirefoxProfile", "start-maximized");

        }
        //------REMOTE
        //Instance = new RemoteWebDriver(new Uri("http://192.168.117.69:4444/wd/hub"), options);
        //c:\SelTools>java -Dwebdriver.chrome.driver=C:\SelTools\chromedriver.exe -jar selenium-server-standalone-3.8.1.jar
        //c:\SelTools>java -jar selenium-server-standalone-3.8.1.jar -role hub
        // C:\SelTools>java -Dwebdriver.chrome.driver=C:\SelTools\chromedriver.exe -jar selenium-server-standalone-3.8.1.jar -role node -hub http://192.168.117.69:4444/wd/hub -capabilities browserName=firefox,maxInstances=3 -capabilities browserName=chrome,maxInstances=3
        //c:\SelTools>java -Dwebdriver.firefox.driver=C:\SelTools\geckodriver.exe -jar selenium-server-standalone-3.8.1.jar -role node -port 5556 -hub http://192.168.117.69:4444/wd/hub -capabilities browserName=firefox,maxInstances=4 -capabilities browserName=chrome,maxInstances=4
        //ehealth@ubuntu:~$ xvfb-run java -Dwebdriver.chrome.driver=/usr/local/bin/chromedriver -jar /usr/local/bin/selenium-server-standalone.jar -role node -port 5559 -hub http://192.168.117.69:4444/wd/hub -capabilities browserName=firefox,maxInstances=3 -capabilities browserName=chrome,maxInstances=3
        
        #endregion
        public void Close()
        {
            driver.Close();
        }

        public void Quit()
        {
            driver.Quit();
        }

        #region WAITS
        public void NoWaiT(Action action)
        {
            TurnOnWait();
            action();
            TurnOffWait();
        }

        public void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void TurnOffWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        
        #endregion

        #region COOKIES&FILES
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
                "{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
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
        #endregion

        public void LoginWithPwd()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("kotov2003@yahoo.com").WithPassword("529zM3").Login();
            Assert.IsTrue(MainPage.IsAt, "Faild to Login");
        }

        public void Exit()
        {
            MainPage.Exit();
        }

        public void LoginWithPhone()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPhone("297033721").GetSMS();
            LoginPage.Close();
            
        }

        public void CheckPopupList()
        {
            MainPage.checkPopupList();            
        }


    }
}
