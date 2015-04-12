using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class RecAreaTests
    {
        [TestMethod]
        public void GetAllRecAreas()
        {
            var ridb = GetClient();
            var result = ridb.GetAllRecreationAreas("yellowstone", null, null, null, null, null, null, null, null);

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetRecArea()
        {
            var ridb = GetClient();
            var result = ridb.GetRecreationArea(6);

            Assert.AreEqual(result.RecAreaID,6);
        }

        private RIDBClient GetClient()
        {
            return new RIDBClient("https://ridb.recreation.gov/api/v1", "0DFAFC81DDA348CF8EE20F3C60280535");
        }
    }
}
