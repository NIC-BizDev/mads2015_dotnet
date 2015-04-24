using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Copyright 2015 NIC Federal

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
namespace NICBizDev.RIDB
{
    /// <summary>
    /// The client module used to access information about RIDB recreation areas.  This module can also be used to
    /// get information about other entities, such as campsites and events, associated with a recreation area.
    /// </summary>
    public class RIDBClientModRecArea : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModRecArea(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all recreation areas in RIDB.  Warning: this retrieves thousands of records and takes
        /// quite a while to pull all pages of recreation area results.  This method should be only used
        /// when all recreation areas need handled.
        /// </summary>
        /// <returns>An array containing all of the facilities in RIDB.</returns>
        public RIDBRecArea[] GetAll()
        {
            GetPageDelegate<RIDBRecArea> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBRecArea>(null, del);
        }

        /// <summary>
        /// Search all of the recreation areas within RIDB and return matches.  All search parameters are supported.  The
        /// Query parameter is applied to the recreation area name, description, keywords, and stay limit fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBRecArea> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecArea>>(url);
        }

        /// <summary>
        /// Get a specific recreation area.
        /// </summary>
        /// <param name="id">The id for the recreation area.</param>
        /// <returns>The recreation area object or null if not found.</returns>
        public RIDBRecArea Get(int id)
        {
            var url = Client.FormatUrl("/recareas/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBRecArea>(url);
        }

        /// <summary>
        /// Retrieve all facilities associated with a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id for the recreation area.</param>
        /// <returns>An array containing all of the facilities associated with an organization.</returns>
        public RIDBFacility[] GetAllFacilities(int recAreaId)
        {
            GetPageDelegate<RIDBFacility> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchFacilities(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBFacility>(null, del);
        }

        /// <summary>
        /// Search the facilities associated with a specific recreation area and return matches.  All search
        /// parameters are supported.  The Query parameter is applied to the facility name, description, keywords, and stay limit fields.
        /// </summary>
        /// <param name="recAreaId">The id for the recreation area.</param>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBFacility> SearchFacilities(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/facilities", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacility>>(url);
        }

        /// <summary>
        /// Get all of the addresses associated with all recreation areas.  Warning:  This retrieves thousands of records!
        /// </summary>
        /// <returns>An array containing ALL of the addresses for all recreation areas.</returns>
        public RIDBRecAreaAddress[] GetAllAddresses()
        {
            GetPageDelegate<RIDBRecAreaAddress> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAddresses(searchParams);
            };
            return Client.GetAll<RIDBRecAreaAddress>(null, del);
        }

        /// <summary>
        /// Search recreation area addresses for all recreation areas and return matches. The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the city, state, postal code, country code,
        /// and street address fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBRecAreaAddress> SearchAddresses(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareaaddresses", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecAreaAddress>>(url);
        }

        /// <summary>
        /// Get all of the addresses associated with a single recreation area.
        /// </summary>
        /// <param name="recAreaId">The id for the recreation area.</param>
        /// <returns>An array of all of the addresses associated with that recreation area.</returns>
        public RIDBRecAreaAddress[] GetAllAddresses(int recAreaId)
        {
            GetPageDelegate<RIDBRecAreaAddress> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAddresses(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBRecAreaAddress>(null, del);
        }

        /// <summary>
        /// Search the addresses for a specific recreation area.  The search utilizes the following search parameters:
        /// Query, Limit, and Offset.  The Query parameter is applied to the city, state, postal code, country code,
        /// and street address fields.
        /// </summary>
        /// <param name="recAreaId">The id for the campsite.</param>
        /// <param name="searchParams">Search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBRecAreaAddress> SearchAddresses(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/recareaaddresses", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecAreaAddress>>(url);
        }

        /// <summary>
        /// Retrieve a specific recreation area address.
        /// </summary>
        /// <param name="recAreaAddressId">The id for the recreation area address.</param>
        /// <returns>The recreation area address or null if not found.</returns>
        public RIDBRecAreaAddress GetAddress(int recAreaAddressId)
        {
            var url = Client.FormatSearchUrl("/recareaaddresses/{0}", new string[] { recAreaAddressId.ToString() }, null);
            //return Client.MakeRequest<RIDBRecAreaAddress>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBRecAreaAddress[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Retrieve all of the media objects associated with a recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <returns>An array of media objects.</returns>
        public RIDBEntityMedia[] GetAllMedia(int recAreaId)
        {
            GetPageDelegate<RIDBEntityMedia> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchMedia(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBEntityMedia>(null, del);
        }

        /// <summary>
        /// Search the media associated with a recreation area.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the title, subtitle, description, credits, and media type fields.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBEntityMedia> SearchMedia(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/media", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityMedia>>(url);
        }

        /// <summary>
        /// Get a specific media item for a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="mediaId">The id of the media object.</param>
        /// <returns>A media object or null if not found.</returns>
        public RIDBEntityMedia GetMedia(int recAreaId, int mediaId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/media/{1}", new string[] { recAreaId.ToString(), mediaId.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityMedia>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEntityMedia[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Retrieve all of the links associated with a recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <returns>An array of link objects.</returns>
        public RIDBEntityLink[] GetAllLinks(int recAreaId)
        {
            GetPageDelegate<RIDBEntityLink> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchLinks(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBEntityLink>(null, del);
        }

        /// <summary>
        /// Search the links associated with a recreation area.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the title, description, and link type fields.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBEntityLink> SearchLinks(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/links", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityLink>>(url);
        }

        /// <summary>
        /// Get a specific link object for a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="entityLinkId">The id of the link object.</param>
        /// <returns>A link object or null if not found.</returns>
        public RIDBEntityLink GetLink(int recAreaId, int entityLinkId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/links/{1}", new string[] { recAreaId.ToString(), entityLinkId.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityLink>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEntityLink[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Retrieve all events associated with a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <returns>An array of event objects.</returns>
        public RIDBEvent[] GetAllEvents(int recAreaId)
        {
            GetPageDelegate<RIDBEvent> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchEvents(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBEvent>(null, del);
        }

        /// <summary>
        /// Search the events associated with a recreation area.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the  event name, start/end date, description, age group, ADA access, fee description, scope
        /// description, and type description fields.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBEvent> SearchEvents(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/events", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEvent>>(url);
        }

        /// <summary>
        /// Get a specific event object for a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="eventId">The id of the event object.</param>
        /// <returns>An event object or null if not found.</returns>
        public RIDBEvent GetEvent(int recAreaId, int eventId)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/events/{1}", new string[] { recAreaId.ToString(), eventId.ToString() }, null);
            //return Client.MakeRequest<RIDBEvent>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEvent[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Get all of the activities associated with a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <returns>An array of activity objects.</returns>
        public RIDBRecAreaActivity[] GetAllActivities(int recAreaId)
        {
            GetPageDelegate<RIDBRecAreaActivity> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchActivities(recAreaId, searchParams);
            };
            return Client.GetAll<RIDBRecAreaActivity>(null, del);
        }

        /// <summary>
        /// Search the activities associated with a recreation area.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the activity name field.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBRecAreaActivity> SearchActivities(int recAreaId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/recareas/{0}/activities", new string[] { recAreaId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecAreaActivity>>(url);
        }

        /// <summary>
        /// Get a specific activity for a specific recreation area.
        /// </summary>
        /// <param name="recAreaId">The id of the recreation area.</param>
        /// <param name="activityId">The id of the activity.</param>
        /// <returns>An activity object or null if not found.</returns>
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
