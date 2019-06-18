using System;
using System.Linq;
using System.IO;
using EdinLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test()
        {
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        public void TestGetList()
        {
            var edin =  EdinFactory.CreateEdin();
            var list =  edin.GetList();
            Assert.AreEqual(list.GetEnumerator().MoveNext(), true);
        }

        [TestMethod]
        public void TestGetDoc()
        {
            var edin = EdinFactory.CreateEdin();
            var list = edin.GetList();
            Assert.AreEqual(list.GetEnumerator().MoveNext(), true);
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            var doc = edin.GetDoc(enumerator.Current);
            Assert.AreNotSame(doc, string.Empty);
        }

        [TestMethod]
        public void TestGetOrder()
        {
            var edin = EdinFactory.CreateEdin();
            var list = edin.GetList();
            Assert.AreEqual(list.GetEnumerator().MoveNext(), true);
            var docName = list.FirstOrDefault(x => x.Contains("order"));
            var doc = edin.GetDoc(docName);
            Assert.AreNotSame(doc, string.Empty);
            Assert.IsNotNull(EdinFactory.GetEdinDoc(docName, doc));
        }

        [TestMethod]
        public void TestSaveAllDocs()
        {
            var edin = EdinFactory.CreateEdin();
            var list = edin.GetList();
            //Assert.AreEqual(list.GetEnumerator().MoveNext(), true);
            foreach (string file in list)
            {
                var doc = edin.GetDoc(file);
                File.WriteAllText(Path.Combine(@"d:\temp\EdiExamples\", file), doc);
            }
        }

        [TestMethod]
        public void TestGetOrderList()
        {
            var emptyVal = EdinFactory.CreateEdin().GetOrderList().GetEnumerator().MoveNext();
            Assert.AreEqual(emptyVal, true);
        }
    }
}
