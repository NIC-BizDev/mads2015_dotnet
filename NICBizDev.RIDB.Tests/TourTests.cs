using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class TourTests : TestBase
    {
        [TestMethod]
        public void TourGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Tour.GetAll();

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void TourSearch()
        {
            var ridb = GetClient();
            var result = ridb.Tour.Search(new RIDBSearchParameters()
            {
                Query = "twilight"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TourGet()
        {
            var ridb = GetClient();
            var result = ridb.Tour.Get(1);

            Assert.AreEqual(result.TourID, 1);
        }

        [TestMethod]
        public void TourSearchAttributes()
        {
            var ridb = GetClient();
            var result = ridb.Tour.SearchAttributes(1, new RIDBSearchParameters() { Query = "distance" });

            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod]
        public void TourGetAllAttributes()
        {
            var ridb = GetClient();
            var result = ridb.Tour.GetAllAttributes(1);

            Assert.IsTrue(result.Length > 0);
        }
    }
}
