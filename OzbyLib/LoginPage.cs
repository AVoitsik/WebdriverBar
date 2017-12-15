using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OzFramework
{
    public class LoginPage:Page
    {
        public LoginPage(IWebDriver driver):base(driver){}

        public  void GoTo()
        {
            driver.FindElement(By.ClassName("top-panel__userbar__auth")).Click();
            //Assert.IsTrue(IsElementPresent(driver, By.Id("loginPopupIntro")));//NoSuchElementException
            Assert.IsTrue(IsElementHasRightText(driver, By.Id("loginPopupIntro"), "Вход"));//NoSuchElementException
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Assert.IsTrue(wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "formInputLoginPhone"));

            /*          ---DIFFERENT WAITS PRACTICE----
                        ReadOnlyCollection<IWebElement> elements = null;
                        Driver.NoWaiT(() => elements =Driver.Instance.FindElements(By.Id("loginPopupIntro")));
             * 
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loginPopupIntro")));  //WebDriverTimeout exception
                        wait.Until(ExpectedConditions.ElementExists(By.Id("loginPopupIntro"))); //WebDriverTimeout exception
                        wait.Until(d => d.FindElement(By.Id("loginPopupIntro")));   //NoSuchElementException
                        Assert.IsTrue(IsElementPresentA(Driver.Instance, By.Id("loginPopupIntro")));    //NoSuchElementException           
                       Assert.IsTrue(wait_e(Driver.Instance,5).Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "formInputLoginPhone"));

                       Assert.IsTrue(IsElementPresent(Driver.Instance, By.Id("loginPopupIntroВ")));//NoSuchElementException
                       Assert.IsTrue(IsElementHasRightText(Driver.Instance, By.Id("loginPopupIntro"), "Вход"));//NoSuchElementException
                       var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                       Assert.IsTrue(wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "formInputLoginPhone"));
             * */
        }

        public  LoginCommand LoginAs(string name)
        {
            return new LoginCommand(driver,wait,name);
        }

        public class LoginCommand:Page
        {
            private IWebDriver driver;
            private WebDriverWait wait;
            private string name;
            private string password;
            private string phone;

            public LoginCommand(IWebDriver driver, WebDriverWait wait, string name)
            {
                this.name=name;
                this.driver = driver;
                this.wait = wait;
            }

            public LoginCommand WithPassword(string password)
            {
                //FindElement(driver, By.Id("loginFormLoginEmailLink"),20).Click();
                driver.FindElement(By.Id("loginFormLoginEmailLink")).Click();
                this.password = password;
                return this;
            }

            public LoginCommand WithPhone(string phone)
            {
                driver.FindElement(By.Id("loginFormLoginPhoneLink")).Click();
                this.phone = phone;
                return this;
            }

            

            public void Login()
            {
                driver.FindElement(By.Name("cl_email")).SendKeys(name);
                driver.FindElement(By.Name("cl_psw")).SendKeys(password);
                driver.FindElement(By.Name("cl_psw")).Submit();
            }

            public void GetSMS()
            {
                driver.FindElement(By.Id("formInputLoginPhone")).SendKeys(phone);
                driver.FindElement(By.CssSelector("#phoneForm button[value=login]")).Click();
                //wait.Until(d=>d.FindElement(By.XPath("//a[.='зарегистрируйтесь']/..")));
                var check = wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[.='зарегистрируйтесь']/.."))).GetAttribute("textContent");

                //var check = driver.FindElement(By.XPath("//a[.='зарегистрируйтесь']/..")).GetAttribute("textContent");
                Assert.IsTrue(check == "Этот номер телефона не зарегистрирован. Проверьте его на ошибки, введите другой или зарегистрируйтесь");
            }
        }
        //formInputLoginPhone  id
        //login  value



            //driver.FindElement(By.Id("loginFormLoginEmailLink")).Click();
            //driver.FindElement(By.Name("cl_email")).SendKeys("kotov2003@yahoo.com");
            //driver.FindElement(By.Name("cl_psw")).SendKeys("529zM3");
            //driver.FindElement(By.Name("cl_psw")).Submit();


        public  void Close()
        {

            //***FIRST OPTION***
            //
            //System.Threading.Thread.Sleep(5000);
            var closeButton = driver.FindElement(By.CssSelector("div#loginPopup > div[data-popup-state=first] > a[href='https://oz.by']"));
            //closeButton.Click();
            //*****************

            //***SECOND OPTION***
            //
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", closeButton);
            //******************

            //***THIRD OPTION***
            //
            //IList<IWebElement> links =
            //    (IList<IWebElement>)
            //        ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(
            //            "arguments[0].scrollIntoView(true);arguments[0].click()", closeButton);
            //
            //*****************



            //**Repeating clicks!!!...CHECK!


            //FAILED OPTIONS
            /*--------ACTIONS didn't help--------------
            Actions actions = new Actions(Driver.Instance);
            actions.MoveToElement(closeButton).Click().Perform();
            ----------------------------------------*/

            /*-IsVisibleOrNote didn't help---
     var block = By.CssSelector("div.i-popup.i-popup_compact.i-popup_large");           
     WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
     var el = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(block));
     --------------------------------*/




            /*Из опыта:
1) бывает div которая накрывает страницу во время загрузки - тогда надо дождатся чтобы исчез
2) или div типа шапки сайта (как на этом сайте) накрыл вашу кнопку - тогда надо заскролится до элемента
             * 
             * private void scrollToElementAndClick(WebElement element) { 
int yScrollPosition = element.getLocation().getY(); 
js.executeScript("window.scroll(0, " + yScrollPosition + ");"); 
element.click(); }
if you need you could also add in a static offset (if for example you have a page header that is 200px high and always displayed):

public static final int HEADER_OFFSET = 200; 
private void scrollToElementAndClick(WebElement element) { 
int yScrollPosition = element.getLocation().getY() - HEADER-OFFSET; 
js.executeScript("window.scroll(0, " + yScrollPosition + ");"); 
element.click(); 
}
             */




        }
    }
}
