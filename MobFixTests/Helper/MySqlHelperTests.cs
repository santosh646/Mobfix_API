using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobFix.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobFix.Helper.Tests
{
    [TestClass()]
    public class MySqlHelperTests
    {
        [TestMethod()]
        public void ExecuteQueryTest()
        {
            MySqlHelper mySqlHelper = new MySqlHelper();
            var dt = mySqlHelper.ExecuteQuery("test");
            Assert.Fail();
        }
    }
}