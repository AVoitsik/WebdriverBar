using System;
using System.Collections.Generic;
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
                try
                {
                    var searchEdit = wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "top-s");

                }
                catch (StaleElementReferenceException ex)
                {
                    MessageBox.Show("Ошибка!");
                }
                var loginName = driver.FindElement(By.CssSelector("ul.top-panel__userbar li.top-panel__userbar_withdrop span>span")).Text == "alexey.voitsyk";
                var searchEdit2 = driver.SwitchTo().ActiveElement().GetAttribute("id") == "top-s";
                return loginName;
            }
        }

        public  void Exit()
        {
            driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner")).Click();
            driver.FindElement(By.LinkText("Выйти")).Click();
            Assert.IsTrue(IsElementPresent(driver, By.CssSelector("a.top-panel__userbar__auth")));
        }

        public  void GoToOrders()
        {
            var loginName = driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));
            var ordersLinkBy = By.XPath("//span[.='Заказы']");
            var ordersLink = driver.FindElement(ordersLinkBy);

            Actions actions = new Actions(driver).MoveToElement(loginName);
            actions.Perform();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(ordersLinkBy));
            //--ALTERNATIVE WAY--//
            //wait.Until(d=>d.FindElement(ordersLinkBy).GetCssValue("visibility")=="visible");

            Actions actions2 = new Actions(driver).MoveToElement(ordersLink).Click(); 
            actions2.Perform();
            wait.Until(ExpectedConditions.TitleIs("Мои заказы — OZ.by"));
        }

        public  void checkPopupList()
        {
            IWebElement loginName = driver.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));
            By popup = By.CssSelector("ul#mobile-userbar");
            By linksList = By.CssSelector("ul#mobile-userbar .top-panel__userbar__ppnav__name");
            IReadOnlyCollection<IWebElement> list = driver.FindElements(linksList);
            List<string> expected = new List<string>() { "Заказы", "Лента событий", "Состояние счёта", "Персональная скидка", "Подписки" };

            Actions actions = new Actions(driver).MoveToElement(loginName).Click();
            actions.Perform();

            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginName);

            wait.Until(ExpectedConditions.ElementIsVisible(popup));

            List<string> actual = new List<string>();
            foreach (var item in list)
            {
                actual.Add(item.Text);
                //spisok_after.Add(item.Text);
                //spisok_after.Add((item.Displayed).ToString());
                //spisok_after.Add((item.Enabled).ToString());
                //spisok_after.Add((item.Selected).ToString());
                //spisok_after.Add((item.GetAttribute("hidden")));//hidden
                //spisok_after.Add((item.GetAttribute("outerHTML")));//hidden
                //spisok_after.Add((item.GetAttribute("textContent")));//hidden
                //spisok_after.Add((item.GetCssValue("visibility")));
                //spisok_after.Add((item.GetCssValue("display")));
                //spisok_after.Add((item.GetCssValue("opacity")));
                //Заказы
                //Лента событий
                //Состояние счёта
                //Персональная скидка
                //Подписки
            }

            Assert.IsTrue(expected.Except(actual).Count() == 0);
        }
    }
}
