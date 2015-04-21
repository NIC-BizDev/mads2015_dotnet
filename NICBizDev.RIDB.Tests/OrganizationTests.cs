using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class OrganizationTests : TestBase
    {
        [TestMethod]
        public void OrgGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Organization.GetAll();

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void OrgSearch()
        {
            var ridb = GetClient();
            var searchParams = new RIDBSearchParameters() { Query = "park" };
            var result = ridb.Organization.Search(searchParams);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void OrgGet()
        {
            var ridb = GetClient();
            var result = ridb.Organization.Get(128);

            Assert.AreEqual(128, result.OrgId);
        }

        [TestMethod]
        public void OrgGetAllRecAreas()
        {
            var ridb = GetClient();
            var result = ridb.Organization.GetAllRecAreas(128);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void OrgSearchRecAreas()
        {
            var ridb = GetClient();
            var searchParams = new RIDBSearchParameters() { Query = "yellowstone" };
            var result = ridb.Organization.SearchRecAreas(128, searchParams);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void OrgGetAllFacilities()
        {
            var ridb = GetClient();
            var result = ridb.Organization.GetAllFacilities(128);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void OrgSearchFacilities()
        {
            var ridb = GetClient();
            var searchParams = new RIDBSearchParameters() { Query = "yellowstone" };
            var result = ridb.Organization.SearchFacilities(128, searchParams);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
