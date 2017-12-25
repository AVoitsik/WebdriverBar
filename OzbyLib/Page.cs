using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        protected Page()
        {
        }



        public bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                var check = wait.Timeout;
                wait.Until(ExpectedConditions.ElementExists(locator));
                //wait.Until(d => d.FindElement(locator));
                //driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public bool IsElementPresentA(IWebDriver driver, By locator)
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

        public bool IsElementHasRightText(IWebDriver driver, By locator, string expected_text)
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

        public void WaitABit(TimeSpan fromSeconds)
        {
            System.Threading.Thread.Sleep((int)fromSeconds.TotalSeconds * 1000);
            //Thread.Sleep(fromSeconds);
        }

        protected IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds = 60)
        {
            var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return waits.Until(ExpectedConditions.ElementExists(by));                           
        }

    }
}
