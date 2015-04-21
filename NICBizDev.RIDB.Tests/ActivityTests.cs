using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class ActivityTests
    {
        [TestMethod]
        public void ActivityGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Activity.GetAll();

            Assert.IsTrue(result.Length > 0);
        }


        [TestMethod]
        public void ActivitySearch()
        {
            var ridb = GetClient();
            var result = ridb.Activity.Search(new RIDBSearchParameters()
            {
                Query = "fishing"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void ActivityGet()
        {
            var ridb = GetClient();
            var result = ridb.Activity.Get(4);

            Assert.AreEqual(result.ActivityID, 4);
        }

        private RIDBClient GetClient()
        {
            return new RIDBClient("https://ridb.recreation.gov/api/v1", "0DFAFC81DDA348CF8EE20F3C60280535");
        }
    }
}
