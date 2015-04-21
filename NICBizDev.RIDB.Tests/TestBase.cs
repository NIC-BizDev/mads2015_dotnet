using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB.Tests
{
    public class TestBase
    {
        protected RIDBClient GetClient()
        {
            return new RIDBClient();
        }
    }
}
