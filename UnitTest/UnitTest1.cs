using System;
using System.IO;
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
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            var doc = edin.GetDoc(enumerator.Current);
            Assert.AreNotSame(doc, string.Empty);
            Assert.IsNotNull(EdinFactory.GetEdinDoc(enumerator.Current, doc));
        }

        [TestMethod]
        public void TestSaveAllDocs()
        {
            var edin = EdinFactory.CreateEdin();
            var list = edin.GetList();
            Assert.AreEqual(list.GetEnumerator().MoveNext(), true);
            foreach (string file in list)
            {
                var doc = edin.GetDoc(file);
                File.WriteAllText(Path.Combine(@"c:\Users\shest\source\repos\EdiIntegration\UnitTest\Examples\", file), doc);
            }
        }
    }
}
