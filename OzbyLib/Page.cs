using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{
    public class Page
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }



        public static bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }   
        }

        public static bool IsElementPresentA(IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElements(locator).Count > 0;
                
            }
            catch (NoSuchElementException ex)
            { 
                return false;
            }
        }

        public static bool IsElementHasRightText(IWebDriver driver, By locator, string expected_text)
        {

            try
            {                
                return driver.FindElement(locator).Text == expected_text;                
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public static WebDriverWait wait_e(IWebDriver driver, int sec)
        {

            return new WebDriverWait(driver, TimeSpan.FromSeconds(sec));            

        }


    }
}
