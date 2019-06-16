using System;
using EdinLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetList()
        {
            var edin =  EdinFactory.CreateEdin();
            var list =  edin.GetList();
            Assert.AreEqual(list.GetEnumerator().MoveNext(), true);
        }
    }
}
