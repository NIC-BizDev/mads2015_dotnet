using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModPermitEntrance : RIDBClientModule
    {
        public RIDBClientModPermitEntrance(RIDBClient client) : base(client) { ; }

        public RIDBPermitEntrance[] GetAll()
        {
            GetPageDelegate<RIDBPermitEntrance> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBPermitEntrance>(null, del);
        }

        public RIDBList<RIDBPermitEntrance> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/permitentrances", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermitEntrance>>(url);
        }

        public RIDBPermitEntrance Get(int id)
        {
            var url = Client.FormatUrl("/permitentrances/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBPermitEntrance>(url);
        }

        public RIDBList<RIDBAttribute> SearchAttributes(int permitEntranceId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/permitentrances/{0}/attributes", new string[] { permitEntranceId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBAttribute>>(url);
        }

        public RIDBAttribute[] GetAllAttributes(int permitEntranceId)
        {
            GetPageDelegate<RIDBAttribute> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAttributes(permitEntranceId, searchParams);
            };
            return Client.GetAll<RIDBAttribute>(null, del);
        }
        public RIDBList<RIDBPermitEntranceZone> SearchZones(int permitEntranceId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/permitentrances/{0}/zones", new string[] { permitEntranceId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermitEntranceZone>>(url);
        }

        public RIDBPermitEntranceZone[] GetAllZones(int permitEntranceId)
        {
            GetPageDelegate<RIDBPermitEntranceZone> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchZones(permitEntranceId, searchParams);
            };
            return Client.GetAll<RIDBPermitEntranceZone>(null, del);
        }

        public RIDBPermitEntranceZone GetZone(int permitEntranceId, int permitEntranceZoneId)
        {
            var url = Client.FormatUrl("/permitentrances/{0}/zones/{1}", new string[] { permitEntranceId.ToString(), permitEntranceZoneId.ToString() }, null);
            //return Client.MakeRequest<RIDBPermitEntranceZone>(url);
            // RIDB BUG:  Instead of returning a single permit entrance zone object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBPermitEntranceZone[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

    }
}
