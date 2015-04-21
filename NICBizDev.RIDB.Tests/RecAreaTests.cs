using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class RecAreaTests : TestBase
    {
        [TestMethod]
        public void RecAreaGetAll()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAll();

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearch()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.Search(new RIDBSearchParameters() { Query = "yellowstone" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaSearchAllParams()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.Search(new RIDBSearchParameters() {
                Query = "yellowstone",
                Limit = 25,
                Offset = 0,
                Latitude = 44.422573,
                Longitude = -110.586700,
                Radius = 100.0,
                StateList = "WY,MT,ID",
                ActivityList = "6,7",
                LastUpdated = DateTime.Today.Subtract(TimeSpan.FromDays(3650))
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGet()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.Get(6);

            Assert.AreEqual(result.RecAreaID,6);
        }

        [TestMethod]
        public void RecAreaGetAllFacilities()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllFacilities(440);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearchFacilities()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchFacilities(440, new RIDBSearchParameters() { Query = "williams" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGetAllAddressesForAll()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllAddresses();

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaGetAllAddresses()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllAddresses(440);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearchAddressesForAll()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchAddresses(new RIDBSearchParameters() { Query = "GA" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaSearchAddresses()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchAddresses(440, new RIDBSearchParameters() { Query = "GA" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGetAddress()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAddress(53739);

            Assert.AreEqual(result.RecAreaAddressID, 53739);
        }

        [TestMethod]
        public void RecAreaGetAllMedia()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllMedia(440);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearchMedia()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchMedia(440, new RIDBSearchParameters() { Query = "campground" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGetMedia()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetMedia(440, 2153);

            // RIDB BUG:  No media ID is returned when pulling a single media item
            //Assert.AreEqual(result.MediaID, 2153);
            Assert.AreEqual(result.EntityID, 440);
        }

        [TestMethod]
        public void RecAreaGetAllLinks()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllLinks(440);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearchLinks()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchLinks(440, new RIDBSearchParameters() { Query = "lake" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGetLink()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetLink(440, 410775);

            // RIDB BUG:  The EntityLinkId is not returned when getting a specific link
            //Assert.AreEqual(result.EntityLinkID, 410775);
            Assert.AreEqual(440, result.EntityID);
        }

        [TestMethod]
        public void RecAreaGetAllEvents()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllEvents(440);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearchEvents()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchEvents(440, new RIDBSearchParameters() { Query = "cleanup" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGetEvent()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetEvent(440, 10834);

            Assert.AreEqual(result.EventID, 10834);
        }

        [TestMethod]
        public void RecAreaGetAllActivities()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetAllActivities(440);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RecAreaSearchActivities()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.SearchActivities(440, new RIDBSearchParameters() { Query = "fishing" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void RecAreaGetActivity()
        {
            var ridb = GetClient();
            var result = ridb.RecArea.GetActivity(440, 11);

            Assert.AreEqual(result.ActivityID, 11);
        }
    }
}
