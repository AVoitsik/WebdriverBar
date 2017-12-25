using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OzTests
{
    [TestFixture]
    public class DiscountTests:TestBase
    {
        [Test]
        public void CheckGoToDiscountPageViaMenuOverLoginnameTest()
        {
            app.LoginWithPwd();
            app.CheckGoToDiscountPageViaMenuOverLoginname();
            app.Logout();
        }
    }
}
