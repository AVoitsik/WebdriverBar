using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{
    public class DiscountPage:Page
    {
        public DiscountPage(IWebDriver driver) : base(driver) { }
        public DiscountPage VerifyIsAtDiscountPage()
        {
            Assert.IsTrue(wait.Until(ExpectedConditions.TitleIs("Ваша скидка OZ.by")));
            return this;
        }
    }

    
}
