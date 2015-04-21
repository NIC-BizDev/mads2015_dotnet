using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class CampsiteTests : TestBase
    {
        //[TestMethod]
        public void CampsiteGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.GetAll();

            Assert.IsTrue(result.Length > 0);
        }


        [TestMethod]
        public void CampsiteSearch()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.Search(new RIDBSearchParameters()
            {
                Query = "yellowstone"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void CampsiteGet()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.Get(51458);

            Assert.AreEqual(result.CampsiteID, 51458);
        }

        [TestMethod]
        public void CampsiteGetAllPermittedEquipment()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.GetAllPermittedEquipment(51458);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void CampsiteSearchPermittedEquipment()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.SearchPermittedEquipment(51458, new RIDBSearchParameters() { Query = "fifth" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void CampsiteSearchAttributes()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.SearchAttributes(51458, new RIDBSearchParameters() { Query = "max" });

            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod]
        public void CampsiteGetAllAttributes()
        {
            var ridb = GetClient();
            var result = ridb.Campsite.GetAllAttributes(51458);

            Assert.IsTrue(result.Length > 0);
        }
    }
}
