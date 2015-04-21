using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class PermitEntranceTests : TestBase
    {
        [TestMethod]
        public void PermitEntranceGetAll()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.GetAll();

            Assert.IsTrue(result.Length > 0);
        }


        [TestMethod]
        public void PermitEntranceSearch()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.Search(new RIDBSearchParameters()
            {
                Query = "yellowstone"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void PermitEntranceGet()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.Get(1);

            Assert.AreEqual(result.PermitEntranceID, 1);
        }

        [TestMethod]
        public void PermitEntranceSearchAttributes()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.SearchAttributes(1, new RIDBSearchParameters() { Query = "important" });

            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod]
        public void PermitEntranceGetAllAttributes()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.GetAllAttributes(1);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void PermitEntranceGetAllZones()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.GetAllZones(169);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void PermitEntranceSearchZones()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.SearchZones(169, null);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void PermitEntranceGetZone()
        {
            var ridb = GetClient();
            var result = ridb.PermitEntrance.GetZone(169, 14799);

            Assert.AreEqual(14799, result.PermitEntranceZoneID);
        }


    }
}
