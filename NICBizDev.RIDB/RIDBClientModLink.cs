using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModLink : RIDBClientModule
    {
        public RIDBClientModLink(RIDBClient client) : base(client) { ; }

        public RIDBEntityLink[] GetAll()
        {
            GetPageDelegate<RIDBEntityLink> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBEntityLink>(null, del);
        }

        public RIDBList<RIDBEntityLink> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/links", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityLink>>(url);
        }

        public RIDBEntityLink Get(int id)
        {
            var url = Client.FormatUrl("/links/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityLink>(url);
            // RIDB BUG:  Instead of returning a single entity link object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBEntityLink[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
