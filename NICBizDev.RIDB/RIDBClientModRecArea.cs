using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    public class RIDBClientModRecArea : RIDBClientModule
    {
        public RIDBClientModRecArea(RIDBClient client) : base(client) { ; }

        public RIDBRecArea[] GetAll()
        {
            GetPageDelegate<RIDBRecArea> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBRecArea>(null, del);
        }

        public RIDBList<RIDBRecArea> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecArea>>(url);
        }

        public RIDBRecArea Get(int id)
        {
            var url = Client.FormatUrl("/recareas/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBRecArea>(url);
        }

        public RIDBFacility[] GetAllFacilities(int recAreaId)
        {
            GetPageDelegate<RIDBFacility> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchFacilities(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBFacility>(null, del);
        }

        public RIDBList<RIDBFacility> SearchFacilities(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/facilities", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacility>>(url);
        }

        public RIDBRecAreaAddress[] GetAllAddresses()
        {
            GetPageDelegate<RIDBRecAreaAddress> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAddresses(searchParams);
            };
            return Client.GetAll<RIDBRecAreaAddress>(null, del);
        }

        public RIDBList<RIDBRecAreaAddress> SearchAddresses(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareaaddresses", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecAreaAddress>>(url);
        }

        public RIDBRecAreaAddress[] GetAllAddresses(int recAreaId)
        {
            GetPageDelegate<RIDBRecAreaAddress> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAddresses(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBRecAreaAddress>(null, del);
        }

        public RIDBList<RIDBRecAreaAddress> SearchAddresses(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/recareaaddresses", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecAreaAddress>>(url);
        }

        public RIDBRecAreaAddress GetAddress(int recAreaAddressId)
        {
            var url = Client.FormatSearchUrl("/recareaaddresses/{0}", new string[] { recAreaAddressId.ToString() }, null);
            //return Client.MakeRequest<RIDBRecAreaAddress>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBRecAreaAddress[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        public RIDBEntityMedia[] GetAllMedia(int recAreaId)
        {
            GetPageDelegate<RIDBEntityMedia> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchMedia(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBEntityMedia>(null, del);
        }

        public RIDBList<RIDBEntityMedia> SearchMedia(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/media", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityMedia>>(url);
        }

        public RIDBEntityMedia GetMedia(int recAreaId, int mediaId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/media/{1}", new string[] { recAreaId.ToString(), mediaId.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityMedia>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEntityMedia[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        public RIDBEntityLink[] GetAllLinks(int recAreaId)
        {
            GetPageDelegate<RIDBEntityLink> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchLinks(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBEntityLink>(null, del);
        }

        public RIDBList<RIDBEntityLink> SearchLinks(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/links", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityLink>>(url);
        }

        public RIDBEntityLink GetLink(int recAreaId, int entityLinkId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/links/{1}", new string[] { recAreaId.ToString(), entityLinkId.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityLink>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEntityLink[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        public RIDBEvent[] GetAllEvents(int recAreaId)
        {
            GetPageDelegate<RIDBEvent> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchEvents(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBEvent>(null, del);
        }

        public RIDBList<RIDBEvent> SearchEvents(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/events", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEvent>>(url);
        }

        public RIDBEvent GetEvent(int recAreaId, int eventId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/events/{1}", new string[] { recAreaId.ToString(), eventId.ToString() }, null);
            //return Client.MakeRequest<RIDBEvent>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEvent[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        public RIDBRecAreaActivity[] GetAllActivities(int recAreaId)
        {
            GetPageDelegate<RIDBRecAreaActivity> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchActivities(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBRecAreaActivity>(null, del);
        }

        public RIDBList<RIDBRecAreaActivity> SearchActivities(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/activities", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecAreaActivity>>(url);
        }

        public RIDBRecAreaActivity GetActivity(int recAreaId, int activityId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/activities/{1}", new string[] { recAreaId.ToString(), activityId.ToString() }, null);
            //return Client.MakeRequest<RIDBRecAreaActivity>(url);
            // RIDB BUG:  This call should return a single object but returns a single element array instead
            var resultArray = Client.MakeRequest<RIDBRecAreaActivity[]>(url);
            if (resultArray == null || resultArray.Length == 0) return null;
            return resultArray[0];
        }

    }
}
