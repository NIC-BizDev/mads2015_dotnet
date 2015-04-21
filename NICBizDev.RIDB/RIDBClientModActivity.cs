using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModActivity : RIDBClientModule
    {
        public RIDBClientModActivity(RIDBClient client) : base(client) { ; }

        public RIDBActivity[] GetAll()
        {
            GetPageDelegate<RIDBActivity> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBActivity>(null, del);
        }

        public RIDBList<RIDBActivity> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/activities", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBActivity>>(url);
        }

        public RIDBActivity Get(int id)
        {
            var url = Client.FormatUrl("/activities/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBActivity>(url);
            // RIDB BUG:  Instead of returning a single activity object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBActivity[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
