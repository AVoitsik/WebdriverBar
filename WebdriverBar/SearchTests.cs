using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OzTests
{
    [TestFixture]
    public class SearchTests:TestBase
    {
        [Test,TestCaseSource(typeof(DataProviders),"ValidSearchData")]
        public void CheckSearchBookTest(SearchData data)
        {
            app.LoginWithPwd();
            app.SearchBookTest(data.ItemToSearch, data.NumberOfFoundItems);
            app.Logout();
        }
    }
}
