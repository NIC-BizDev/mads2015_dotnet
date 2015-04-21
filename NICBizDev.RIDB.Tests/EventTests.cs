using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class EventTests : TestBase
    {
        [TestMethod]
        public void EventGetAll()
        {
            var ridb = GetClient();
            var result = ridb.Event.GetAll();

            Assert.IsTrue(result.Length > 0);
        }


        [TestMethod]
        public void EventSearch()
        {
            var ridb = GetClient();
            var result = ridb.Event.Search(new RIDBSearchParameters()
            {
                Query = "lake"
            });

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void EventGet()
        {
            var ridb = GetClient();
            var result = ridb.Event.Get(10835);

            Assert.AreEqual(result.EventID, 10835);
        }
    }
}
