using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OzbyLib
{
    public class MainPage
    {
        public static bool IsAt
        {
            get
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                //var result = wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "top-s");
                //ul.top-panel__userbar li.top-panel__userbar_withdrop span>span[textContent=alexey.voitsyk]
                var loginName = Driver.Instance.FindElement(By.CssSelector("ul.top-panel__userbar li.top-panel__userbar_withdrop span>span")).Text=="alexey.voitsyk";
                 var loginName2 = Driver.Instance.SwitchTo().ActiveElement().GetAttribute("id") == "top-s";
                return loginName;
            }
        }
         
    }
}
