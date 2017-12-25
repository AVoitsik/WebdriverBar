using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{
    public class MainPage:Page
    {
        public MainPage (IWebDriver driver) : base(driver) { }
        public  bool IsAt
        {
            get
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                ////wait.Until(d=>d.SwitchTo().ActiveElement().GetAttribute("id") == "top-s"); ->Stale reffrernce issue
                //var check = driver.SwitchTo().ActiveElement();
                //wait.Until(ExpectedConditions.StalenessOf(check));                    
                //wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "top-s");  -> ISSUE in FF on ActiveElement(can't convert to object)
                var loginName = FindElement(driver, By.CssSelector("ul.top-panel__userbar li.top-panel__userbar_withdrop span>span")).Text == "alexey.voitsyk";
                return loginName;
            }
        }

        public  void Logout()
        {
            driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner")).Click();
            FindElement(driver, By.LinkText("Выйти")).Click();
           //wait.Until(d=>d.FindElement(By.LinkText("Выйти"))).Click();
            Assert.IsTrue(IsElementPresent(driver, By.CssSelector("a.top-panel__userbar__auth")));
        }

        public OrdersPage GoToOrdersPageViaMenuOverLoginName()
        {
            By popupMenuItemBy = By.XPath("//span[.='Заказы']");
            ClickPopupMenuItem(popupMenuItemBy);
            return new OrdersPage(driver);
        }

        public DiscountPage GoToDiscountPageViaMenuOverLoginName()
        {
            By popupMenuItemBy = By.XPath("//span[.='Персональная скидка']");
            ClickPopupMenuItem(popupMenuItemBy);
            return new DiscountPage(driver);
        }

        private void ClickPopupMenuItem(By popupMenuItemBy)
        {
            WebDriverWait waitForPopupMenu = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForPopupMenu.Until(
                ExpectedConditions
                    .ElementIsVisible(
                        popupMenuItemBy)); //ALTERNATIVE//wait.Until(d=>d.FindElement(ordersLinkBy).GetCssValue("visibility")=="visible");

            IWebElement ordersPopupLink = driver.FindElement(popupMenuItemBy);
            Actions clickOrdersPopupLink = new Actions(driver).MoveToElement(ordersPopupLink).Click();
            clickOrdersPopupLink.Perform();
        }


        public void VerifyMenuOverLoginName()
        {
            List<string> expectedMenuItems = new List<string>() { "Заказы", "Лента событий", "Состояние счёта", "Персональная скидка", "Подписки" };

            By popupMenuBy = By.CssSelector("ul#mobile-userbar");
            By popupMenuItemListBy = By.CssSelector("ul#mobile-userbar .top-panel__userbar__ppnav__name");
            IReadOnlyCollection<IWebElement> popupMenuItemList = driver.FindElements(popupMenuItemListBy);
            wait.Until(ExpectedConditions.ElementIsVisible(popupMenuBy));
            List<string> actualMenuItems = new List<string>();
            foreach (var item in popupMenuItemList)
            {
                actualMenuItems.Add(item.GetAttribute("textContent"));
            }
            Assert.IsTrue(expectedMenuItems.Any(item => actualMenuItems.Contains(item)));
        }

        public MainPage ShowMenuOverLoginname()
        {
            IWebElement loginNameLink = driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));
            Actions moveCursorToLoginName = new Actions(driver).MoveToElement(loginNameLink);
            moveCursorToLoginName.Perform();
            return this;
        }

        public SearchPage SearchFor(string book)
        {
            IWebElement searchField = driver.FindElement(By.Id("top-s"));
            searchField.SendKeys(book);
            //serachButton.SendKeys(Keys.Enter);
            IWebElement searchButton = driver.FindElement(By.ClassName("top-panel__search__btn"));
            searchButton.Click();
            return new SearchPage(driver);
        }
    }


}
