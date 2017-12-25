using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OzTests
{
    [TestFixture]
    public class OrdersTest:TestBase
    {
        [Test]
        //No FF
        public void CheckGoToOrdersPageViaMenuOverLoginnameTest()
        {
            app.LoginWithPwd();
            app.CheckGoToOrdersPageViaMenuOverLoginname();
            app.Logout();
        }

        [Test]
        public void CheckSidebarMenuOnOrdersPageTest()
        {
            app.LoginWithPwd();
            app.CheckSidebarMenuOnOrdersPage();
            app.Logout();
        }

        [Test]
        //No FF
        public void CheckGoToDiscountPageViaSidebarMenuTest()
        {
            app.LoginWithPwd();
            app.CheckGoToDiscountPageViaSidebarMenu();
            app.Logout();
        }
    }
}
