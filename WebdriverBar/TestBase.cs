using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzFramework;

namespace OzTests
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
