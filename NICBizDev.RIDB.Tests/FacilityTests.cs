using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class FacilityTests : TestBase
    {
        [TestMethod]
        public void FacilityGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAll();

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearch()
        {
            var ridb = GetClient();
            var result = ridb.Facility.Search(new RIDBSearchParameters() {
                Query = "yellowstone"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGet()
        {
            var ridb = GetClient();
            var result = ridb.Facility.Get(234569);

            Assert.AreEqual(result.FacilityID, 234569);
        }

        [TestMethod]
        public void FacilityGetAllAddressesForAll()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllAddresses();

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilityGetAllAddresses()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllAddresses(231827);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchAddressesForAll()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchAddresses(new RIDBSearchParameters() { Query = "WY" });
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilitySearchAddresses()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchAddresses(231827, new RIDBSearchParameters() { Query = "WY" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetAddress()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAddress(23038);

            Assert.AreEqual(result.FacilityAddressID, 23038);
        }

        [TestMethod]
        public void FacilityGetAllMedia()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllMedia(231827);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchMedia()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchMedia(231827, new RIDBSearchParameters() { Query = "landmark" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetMedia()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetMedia(231827, 1726);

            // RIDB BUG:  No media ID is returned when pulling a single media item
            //Assert.AreEqual(result.MediaID, 2153);
            Assert.AreEqual(result.EntityID, 231827);
        }

        [TestMethod]
        public void FacilityGetAllLinks()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllLinks(231827);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchLinks()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchLinks(231827, new RIDBSearchParameters() { Query = "learn" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetLink()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetLink(231827, 43834);

            // RIDB BUG:  The EntityLinkId is not returned when getting a specific link
            //Assert.AreEqual(result.EntityLinkID, 410775);
            Assert.AreEqual(231827, result.EntityID);
        }

        [TestMethod]
        public void FacilityGetAllEvents()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllEvents(200001);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchEvents()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchEvents(200001, new RIDBSearchParameters() { Query = "test" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetEvent()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetEvent(200001, 10021);

            Assert.AreEqual(result.EventID, 10021);
        }

        [TestMethod]
        public void FacilityGetAllActivities()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllActivities(231827);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchActivities()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchActivities(231827, new RIDBSearchParameters() { Query = "fishing" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetActivity()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetActivity(231827, 11);

            Assert.AreEqual(result.ActivityID, 11);
        }

        [TestMethod]
        public void FacilityGetAllCampsites()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllCampsites(233816);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchCampsites()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchCampsites(233816, new RIDBSearchParameters() { Query = "group" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetAllPermitEntrances()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllPermitEntrances(233260);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchPermitEntrances()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchPermitEntrances(233260, new RIDBSearchParameters() { Query = "ansel" });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FacilityGetAllTours()
        {
            var ridb = GetClient();
            var result = ridb.Facility.GetAllTours(233362);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void FacilitySearchTours()
        {
            var ridb = GetClient();
            var result = ridb.Facility.SearchTours(233362, new RIDBSearchParameters() { Query = "twilight" });

            Assert.IsTrue(result.Count > 0);
        }
    }
}
