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
    public class LoginPage
    {


        public static void GoTo()
        {
            Driver.Instance.FindElement(By.ClassName("top-panel__userbar__auth")).Click();
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            var check1 = wait.Until(d => d.FindElement(By.Id("loginPopupIntro")).Text=="Вход");
           var check2 = wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "formInputLoginPhone");
        }

        public static LoginCommand LoginAs(string name)
        {
            return new LoginCommand(name);
        }

        public class LoginCommand
        {
            private string name;
            private string password;

            public LoginCommand(string name){
                this.name=name;
            }

            public LoginCommand WithPassword(string password)
            {
                this.password = password;
                return this;
            }

            public void Login()
            {
                Driver.Instance.FindElement(By.Id("loginFormLoginEmailLink")).Click();
                Driver.Instance.FindElement(By.Name("cl_email")).SendKeys(name);
                Driver.Instance.FindElement(By.Name("cl_psw")).SendKeys(password);
                Driver.Instance.FindElement(By.Name("cl_psw")).Submit();
            }
        }




            //driver.FindElement(By.Id("loginFormLoginEmailLink")).Click();
            //driver.FindElement(By.Name("cl_email")).SendKeys("kotov2003@yahoo.com");
            //driver.FindElement(By.Name("cl_psw")).SendKeys("529zM3");
            //driver.FindElement(By.Name("cl_psw")).Submit();
        
    }
}
