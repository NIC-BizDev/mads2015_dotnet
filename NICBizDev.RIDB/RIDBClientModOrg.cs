using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModOrg : RIDBClientModule
    {
        public RIDBClientModOrg(RIDBClient client) : base(client) { ; }

        public RIDBOrganization[] GetAll()
        {
            GetPageDelegate<RIDBOrganization> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBOrganization>(null, del);
        }

        public RIDBList<RIDBOrganization> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/organizations/", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBOrganization>>(url);
        }

        public RIDBOrganization Get(int orgId)
        {
            var url = Client.FormatSearchUrl("/organizations/{0}", new string[] { orgId.ToString() }, null);
            // RIDB bug:  For some reason this call returns a single element array instead of just the organization object
            var workaround = Client.MakeRequest<RIDBOrganization[]>(url);
            if (workaround == null || workaround.Length < 1) return null;
            return workaround[0];
        }

        public RIDBRecArea[] GetAllRecAreas(int orgId)
        {
            GetPageDelegate<RIDBRecArea> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchRecAreas(orgId, searchParams);
            };
            return Client.GetAll<RIDBRecArea>(null, del);
        }

        public RIDBList<RIDBRecArea> SearchRecAreas(int orgId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/organizations/{0}/recareas", new string[] { orgId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecArea>>(url);
        }

        public RIDBFacility[] GetAllFacilities(int orgId)
        {
            GetPageDelegate<RIDBFacility> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchFacilities(orgId, searchParams);
            };
            return Client.GetAll<RIDBFacility>(null, del);
        }

        public RIDBList<RIDBFacility> SearchFacilities(int orgId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/organizations/{0}/facilities", new string[] { orgId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacility>>(url);
        }
    }
}
