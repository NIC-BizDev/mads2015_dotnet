using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICBizDev.RIDB.Tests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void TestAllOrganizations()
        {
            var ridb = new RIDBClient("https://ridb.recreation.gov/api/v1", "0DFAFC81DDA348CF8EE20F3C60280535");
            RIDBOrganization[] result = ridb.GetAllOrganizations();

            Assert.IsTrue(result.Length > 0);
        }
    }
}
