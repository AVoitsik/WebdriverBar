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
        public Application app;
        [TestInitialize]
        public void Initialize()
        {
            app = new Application();


        }

        [TestCleanup]
        public void Cleaup()
        {
            app.Close();
            app.Quit();
            app = null;
            //driver.Close();
            //driver.Quit();
            //driver = null;

        }
    }
}
