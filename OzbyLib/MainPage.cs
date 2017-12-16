using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
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

        public  void GoToOrders()
        {
            IWebElement loginNameLink = driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));            
            Actions moveCursorToLoginName = new Actions(driver).MoveToElement(loginNameLink);
            moveCursorToLoginName.Perform();

            By ordersPopupLinkBy = By.XPath("//span[.='Заказы']");
            WebDriverWait waitForPopupMenu= new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForPopupMenu.Until(ExpectedConditions.ElementIsVisible(ordersPopupLinkBy)); //ALTERNATIVE//wait.Until(d=>d.FindElement(ordersLinkBy).GetCssValue("visibility")=="visible");

            IWebElement ordersPopupLink = driver.FindElement(ordersPopupLinkBy);
            Actions clickOrdersPopupLink = new Actions(driver).MoveToElement(ordersPopupLink).Click();
            clickOrdersPopupLink.Perform();
            wait.Until(ExpectedConditions.TitleIs("Мои заказы — OZ.by"));
        }

        public  void checkPopupList()
        {
            List<string> expectedPopupLinks = new List<string>() { "Заказы", "Лента событий", "Состояние счёта", "Персональная скидка", "Подписки" };            
            
            IWebElement loginNameLink = driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));
            Actions moveCursorToLoginName = new Actions(driver).MoveToElement(loginNameLink);
            moveCursorToLoginName.Perform();
            
            By popupMenuBy = By.CssSelector("ul#mobile-userbar");
            By popupMenulinksListBy = By.CssSelector("ul#mobile-userbar .top-panel__userbar__ppnav__name");
            IReadOnlyCollection<IWebElement> popupMenulinksList = driver.FindElements(popupMenulinksListBy);
            wait.Until(ExpectedConditions.ElementIsVisible(popupMenuBy));
            
            List<string> actualPopupLinks = new List<string>();
            foreach (var item in popupMenulinksList)
            {
                actualPopupLinks.Add(item.GetAttribute("textContent"));
            }

            Assert.IsTrue(expectedPopupLinks.Any(link => actualPopupLinks.Contains(link)));
        }
    }
}
