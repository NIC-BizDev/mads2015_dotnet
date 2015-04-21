using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class MediaTests : TestBase
    {
        [TestMethod]
        public void MediaGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Media.GetAll();

            Assert.IsTrue(result.Length > 0);
        }


        [TestMethod]
        public void MediaSearch()
        {
            var ridb = GetClient();
            var result = ridb.Media.Search(new RIDBSearchParameters()
            {
                Query = "lake"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void MediaGet()
        {
            var ridb = GetClient();
            var result = ridb.Media.Get(2264);

            Assert.AreEqual(result.MediaID, 2264);
        }

        
    }
}
