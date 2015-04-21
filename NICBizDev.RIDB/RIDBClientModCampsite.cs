using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModCampsite : RIDBClientModule
    {
        public RIDBClientModCampsite(RIDBClient client) : base(client) { ; }

        public RIDBCampsite[] GetAll()
        {
            GetPageDelegate<RIDBCampsite> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBCampsite>(null, del);
        }

        public RIDBList<RIDBCampsite> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/campsites", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBCampsite>>(url);
        }

        public RIDBCampsite Get(int id)
        {
            var url = Client.FormatUrl("/campsites/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBCampsite>(url);
            // RIDB BUG:  Instead of returning a single campsite object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBCampsite[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        public RIDBList<RIDBPermittedEquipment> SearchPermittedEquipment(int campsiteId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/campsites/{0}/permittedequipment", new string[] { campsiteId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermittedEquipment>>(url);
        }

        public RIDBPermittedEquipment[] GetAllPermittedEquipment(int campsiteId)
        {
            GetPageDelegate<RIDBPermittedEquipment> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchPermittedEquipment(campsiteId, searchParams);
            };
            return Client.GetAll<RIDBPermittedEquipment>(null, del);
        }

        public RIDBPermittedEquipment GetPermittedEquipment(int campsiteId, int permittedEquipmentId)
        {
            var url = Client.FormatUrl("/campsites/{0}/permittedequipment/{1}", new string[] { campsiteId.ToString(), permittedEquipmentId.ToString() }, null);
            //return Client.MakeRequest<RIDBPermittedEquipment>(url);
            // RIDB BUG:  Instead of returning a single permitted equipment object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBPermittedEquipment[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        public RIDBList<RIDBAttribute> SearchAttributes(int campsiteId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/campsites/{0}/attributes", new string[] { campsiteId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBAttribute>>(url);
        }

        public RIDBAttribute[] GetAllAttributes(int campsiteId)
        {
            GetPageDelegate<RIDBAttribute> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAttributes(campsiteId, searchParams);
            };
            return Client.GetAll<RIDBAttribute>(null, del);
        }
    }
}
