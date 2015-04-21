using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModEvent : RIDBClientModule
    {
        public RIDBClientModEvent(RIDBClient client) : base(client) { ; }

        public RIDBEvent[] GetAll()
        {
            GetPageDelegate<RIDBEvent> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBEvent>(null, del);
        }

        public RIDBList<RIDBEvent> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/events", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBEvent>>(url);
        }

        public RIDBEvent Get(int id)
        {
            var url = Client.FormatUrl("/events/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBEvent>(url);
            // RIDB BUG:  Instead of returning a single event object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBEvent[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
