//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzFramework;
using NUnit.Framework;

namespace OzTests
{
    [TestFixture]
    public class TestBase
    {
        public Application app;
        [SetUp]
        public void Initialize()
        {
            app = new Application();
        }

        [TearDown]
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
