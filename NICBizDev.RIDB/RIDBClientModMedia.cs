using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModMedia : RIDBClientModule
    {
        public RIDBClientModMedia(RIDBClient client) : base(client) { ; }

        public RIDBEntityMedia[] GetAll()
        {
            GetPageDelegate<RIDBEntityMedia> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBEntityMedia>(null, del);
        }

        public RIDBList<RIDBEntityMedia> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/media", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityMedia>>(url);
        }

        public RIDBEntityMedia Get(int id)
        {
            var url = Client.FormatUrl("/media/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityMedia>(url);
            // RIDB BUG:  Instead of returning a single media object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBEntityMedia[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
