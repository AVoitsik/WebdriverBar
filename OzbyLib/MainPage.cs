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
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{
    public class MainPage:Helper
    {
        public static bool IsAt
        {
            get
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                try
                {
                    var searchEdit = wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "top-s");

                }
                catch (StaleElementReferenceException ex)
                {
                    MessageBox.Show("Ошибка!");
                }
                var loginName = Driver.Instance.FindElement(By.CssSelector("ul.top-panel__userbar li.top-panel__userbar_withdrop span>span")).Text=="alexey.voitsyk";
                 var searchEdit2 = Driver.Instance.SwitchTo().ActiveElement().GetAttribute("id") == "top-s";
                return loginName;
            }
        }

        public static void Exit()
        {
            Driver.Instance.FindElement(By.ClassName("top-panel__userbar__user__name__inner")).Click();
            Driver.Instance.FindElement(By.LinkText("Выйти")).Click();
            Assert.IsTrue(IsElementPresent(Driver.Instance, By.CssSelector("a.top-panel__userbar__auth")));
        }

        public static void GoToOrders()
        {
            var loginName = Driver.Instance.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));
            var ordersLinkBy = By.XPath("//span[.='Заказы']");
            var ordersLink = Driver.Instance.FindElement(ordersLinkBy);
            
            Actions actions = new Actions(Driver.Instance).MoveToElement(loginName);
            actions.Perform();

            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(ordersLinkBy));
            //--ALTERNATIVE WAY--//
            //wait.Until(d=>d.FindElement(ordersLinkBy).GetCssValue("visibility")=="visible");
            
            Actions actions2 = new Actions(Driver.Instance).MoveToElement(ordersLink).Click(); 
            actions2.Perform();
            wait.Until(ExpectedConditions.TitleIs("Мои заказы — OZ.by"));
        }

        public static void checkPopupList()
        {
            IWebElement loginName = Driver.Instance.FindElement(By.ClassName("top-panel__userbar__user__name__inner"));
            By popup = By.CssSelector("ul#mobile-userbar");
            By linksList = By.CssSelector("ul#mobile-userbar .top-panel__userbar__ppnav__name");
            IReadOnlyCollection<IWebElement> list = Driver.Instance.FindElements(linksList);
            List<string> expected = new List<string>() { "Заказы", "Лента событий", "Состояние счёта", "Персональная скидка", "Подписки" };
                     
            Actions actions = new Actions(Driver.Instance).MoveToElement(loginName);
            actions.Perform();

            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
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
