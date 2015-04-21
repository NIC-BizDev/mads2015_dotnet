using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class LinkTests : TestBase
    {
        [TestMethod]
        public void LinkGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Link.GetAll();

            Assert.IsTrue(result.Length > 0);
        }


        [TestMethod]
        public void LinkSearch()
        {
            var ridb = GetClient();
            var result = ridb.Link.Search(new RIDBSearchParameters()
            {
                Query = "lake"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void LinkGet()
        {
            var ridb = GetClient();
            var result = ridb.Link.Get(2264);

            Assert.AreEqual(result.EntityID, 216861);
        }

    }
}
