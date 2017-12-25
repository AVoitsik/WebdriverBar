using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace OzFramework
{
    public class SearchPage:Page
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        public SearchPage VerifyIsAtSearchPage(string book)
        {
            Assert.IsTrue(driver.Title == ("Результаты поиска по запросу \""+book+"\""));
            return this;
        }

        public SearchPage CheckNumberOfFoundItems(string book, string count)
        {
            IWebElement searchResultMessage = driver.FindElement(By.CssSelector("h1.breadcrumbs__list__item"));
            List<IWebElement> searchResultNumberOfCards = driver.FindElements(By.CssSelector("li.viewer-type-card__li ")).ToList();
            Assert.IsTrue(searchResultMessage.GetAttribute("innerText") == "Найдено "+count+" товаров по запросу «"+book+"»");
            Assert.IsTrue(searchResultNumberOfCards.Count.ToString()==count);
            return this;
        }
    }
}
