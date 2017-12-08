using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppVersionControl.Facade;

namespace AppVersionControl.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AppVersionProvider provider = new AppVersionProvider("yxhv3_android", null, "3.0.0.3");
            AppVersion ver = provider.GetNewVersion();
            Assert.IsTrue(ver != null);
        }
    }
}
