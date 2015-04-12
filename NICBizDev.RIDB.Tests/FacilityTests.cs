using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class FacilityTests
    {
        [TestMethod]
        public void GetAllFacilities()
        {
            var ridb = GetClient();
            var result = ridb.GetAllFacilities("yellowstone", null, null, null, null, null, null, null, null);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetFacility()
        {
            var ridb = GetClient();
            var result = ridb.GetFacility(234569);

            Assert.AreEqual(result.FacilityID, 234569);
        }

        private RIDBClient GetClient()
        {
            return new RIDBClient("https://ridb.recreation.gov/api/v1", "0DFAFC81DDA348CF8EE20F3C60280535");
        }
    }
}
