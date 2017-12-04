using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OzbyLib
{
    public class Helper
    {
        public static bool IsElementPresent(IWebDriver driver, By bylocator)
        {

            try
            {
                driver.FindElement(bylocator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }   
        }
    }
}
