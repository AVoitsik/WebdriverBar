using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzbyLib;

namespace WebdriverBar
{
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();


        }

        [TestCleanup]
        public void Cleaup()
        {
            Driver.Close();
            //driver.Close();
            //driver.Quit();
            //driver = null;

        }
    }
}
