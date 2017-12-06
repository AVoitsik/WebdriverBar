using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace OzFramework
{

    public class Driver
    {
        public static IWebDriver Instance{get;set;}

        public static string BaseAddress{
            get{return "https://oz.by/";}
        }

        public static void Initialize(){
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");
            Instance = new ChromeDriver(options);
            TurnOnWait();//Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Instance.Navigate().GoToUrl(BaseAddress);
        }

        ////            Instance = new RemoteWebDriver(new Uri("http://192.168.117.69:4444/wd/hub"), options);
        //            c:\SelTools>java -Dwebdriver.chrome.driver=C:\SelTools\chromedriver.exe -jar sel
        //enium-server-standalone-3.8.1.jar

        public static void Close(){
            Instance.Close();
        }

        public static void Quit()
        {
            Instance.Quit();
        }

        public static void NoWaiT(Action action)
        {
            TurnOnWait();
            action();
            TurnOffWait();
        }

        public static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public static void Wait(TimeSpan fromSeconds)
        {
            System.Threading.Thread.Sleep((int)fromSeconds.TotalSeconds * 1000);
            //Thread.Sleep(fromSeconds);
        }

    }
}
