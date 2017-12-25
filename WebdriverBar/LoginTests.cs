using NUnit.Framework;


namespace OzTests
{
    [TestFixture]
    public class LoginTests:TestBase
    {        
        //[TestCase("kotov2003@yahoo.com", "529zM3")]
        //public void LoginWithPwdTest(string login, string pwd)
        [Test,TestCaseSource(typeof(DataProviders),"ValidCustomers")]
        public void LoginWithPwdTest(Customer customer)
        {
            app.LoginWithPwd(customer.Login, customer.Password);           
            //CreateCookiesLog(); 
            app.Logout();
        }

        [Test]
        public void LoginWithPhoneTest()
        {
            app.LoginWithPhone();
        }

        [Test]
        //No FF
        public void CheckMenuOverLoginnameTest()
        {
            app.LoginWithPwd();
            app.CheckMenuOverLoginname();            
            app.Logout();           
            //CreateCookiesLog();            
        }




    }
}
