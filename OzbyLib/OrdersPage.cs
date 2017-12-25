using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{
   public class OrdersPage:Page
    {
       public OrdersPage(IWebDriver driver) : base(driver) { }

       public OrdersPage VerifyIsAtOrdersPage()
        {
            wait.Until(ExpectedConditions.TitleIs("Мои заказы — OZ.by"));
            return this;
        }
       public OrdersPage VerifySidebarMenu()
       {
           List<string> expectedMenuItems = new List<string>()
            {
                "Корзина", 
                "Избранное", 
                "Заказы",
                "Лента событий",
                "Личный счёт",
                "Персональная скидка",
                "Дни рождения",
                "Рассылка",
                "Подписки",
                "Уведомления",
                "Личные данные",
                "Адреса доставки",                
                "Правила оформления↵и доставки заказов",
                "Способы оплаты",
                "Статусы заказов",
                "Закажите звонок",
                "Напишите нам"
            };

           By sidebarMenuBy = By.CssSelector(".personal-nav__link ");
           IReadOnlyCollection<IWebElement> sidebarMenuItemList = driver.FindElements(sidebarMenuBy);
           List<string> actualMenuItems = new List<string>();
           foreach (var item in sidebarMenuItemList)
           {
               actualMenuItems.Add(item.GetAttribute("innerText"));
           }
           Assert.IsTrue(expectedMenuItems.Any(item => actualMenuItems.Contains(item)));
           return this;
       }

       public DiscountPage GoToDiscountPage()
       {
           ClickSidebarLink("Персональная скидка");
           return new DiscountPage(driver);
       }

       private void ClickSidebarLink(string link)
       {
           By sidebarMenuBy = By.CssSelector(".personal-nav__link ");
           IReadOnlyCollection<IWebElement> sidebarMenuItemList = driver.FindElements(sidebarMenuBy);
           IWebElement discountLink = null;
           foreach (var item in sidebarMenuItemList)
           {
               if (item.GetAttribute("innerText") == link)
               {
                   discountLink = item;
                   break;
               }
           }
           discountLink.Click();
       }

    }
}
