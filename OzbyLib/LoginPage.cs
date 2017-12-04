using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            private string phone;

            public LoginCommand(string name){
                this.name=name;
            }

            public LoginCommand WithPassword(string password)
            {
                Driver.Instance.FindElement(By.Id("loginFormLoginEmailLink")).Click();
                this.password = password;
                return this;
            }

            public LoginCommand WithPhone(string phone)
            {
                Driver.Instance.FindElement(By.Id("loginFormLoginPhoneLink")).Click();
                this.phone = phone;
                return this;
            }

            

            public void Login()
            {
                Driver.Instance.FindElement(By.Name("cl_email")).SendKeys(name);
                Driver.Instance.FindElement(By.Name("cl_psw")).SendKeys(password);
                Driver.Instance.FindElement(By.Name("cl_psw")).Submit();
            }

            public void GetSMS()
            {
                Driver.Instance.FindElement(By.Id("formInputLoginPhone")).SendKeys(phone);
                Driver.Instance.FindElement(By.CssSelector("#phoneForm button[value=login]")).Click();
                var check = Driver.Instance.FindElement(By.XPath("//a[.='зарегистрируйтесь']/..")).GetAttribute("textContent");
                Assert.IsTrue(check == "Этот номер телефона не зарегистрирован. Проверьте его на ошибки, введите другой или зарегистрируйтесь");
            }
        }
        //formInputLoginPhone  id
        //login  value



            //driver.FindElement(By.Id("loginFormLoginEmailLink")).Click();
            //driver.FindElement(By.Name("cl_email")).SendKeys("kotov2003@yahoo.com");
            //driver.FindElement(By.Name("cl_psw")).SendKeys("529zM3");
            //driver.FindElement(By.Name("cl_psw")).Submit();
        
    }
}
