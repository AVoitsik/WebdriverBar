﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace OzbyLib
{

    public class Driver
    {
        public static IWebDriver Instance{get;set;}

        public static string BaseAddress{
            get{return "https://oz.by/";}
        }

        public static void Initialize(){
             ChromeOptions opt = new ChromeOptions();
            opt.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");
            Instance = new ChromeDriver(opt);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Instance.Navigate().GoToUrl(BaseAddress);
        }

        public static void Close(){
            Instance.Close();
        }
        
    }
}