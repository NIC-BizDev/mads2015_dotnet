using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModTour : RIDBClientModule
    {
        public RIDBClientModTour(RIDBClient client) : base(client) { ; }

        public RIDBTour[] GetAll()
        {
            GetPageDelegate<RIDBTour> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBTour>(null, del);
        }

        public RIDBList<RIDBTour> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/tours", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBTour>>(url);
        }

        public RIDBTour Get(int id)
        {
            var url = Client.FormatUrl("/tours/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBTour>(url);
            
        }

        public RIDBList<RIDBAttribute> SearchAttributes(int tourId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/tours/{0}/attributes", new string[] { tourId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBAttribute>>(url);
        }

        public RIDBAttribute[] GetAllAttributes(int tourId)
        {
            GetPageDelegate<RIDBAttribute> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAttributes(tourId, searchParams);
            };
            return Client.GetAll<RIDBAttribute>(null, del);
        }
    }
}
