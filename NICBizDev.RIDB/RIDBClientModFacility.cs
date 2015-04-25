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
    /// The client module used to access information about RIDB facilities.  To get the facilities associated with a
    /// recreation areas and facilities, use the recreation area module and call one of the facility search or access methods.
    /// </summary>
    public class RIDBClientModFacility : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModFacility(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all facilities in RIDB.  Warning: this retrieves thousands of records and takes
        /// quite a while to pull all pages of facility results.  This method should be only used
        /// when all facilities need handled.
        /// </summary>
        /// <returns>An array containing all of the facilities in RIDB.</returns>
        public RIDBFacility[] GetAll()
        {
            GetPageDelegate<RIDBFacility> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBFacility>(null, del);
        }

        /// <summary>
        /// Search all of the facilities within RIDB and return matches.  All search parameters are supported.  The
        /// Query parameter is applied to the facility name, description, keywords, and stay limit fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBFacility> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacility>>(url);
        }

        /// <summary>
        /// Get a specific facility.
        /// </summary>
        /// <param name="id">The id for the facility.</param>
        /// <returns>The facility object or null if not found.</returns>
        public RIDBFacility Get(int id)
        {
            var url = Client.FormatUrl("/facilities/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBFacility>(url);
        }

        /// <summary>
        /// Get all of the addresses associated with all facilities.  Warning:  This retrieves thousands of records!
        /// </summary>
        /// <returns>An array containing ALL of the addresses for all facilities.</returns>
        public RIDBFacilityAddress[] GetAllAddresses()
        {
            GetPageDelegate<RIDBFacilityAddress> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAddresses(searchParams);
            };
            return Client.GetAll<RIDBFacilityAddress>(null, del);
        }

        /// <summary>
        /// Search facility addresses for all facilities and return matches. The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the city, state, postal code, country code,
        /// and street address fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBFacilityAddress> SearchAddresses(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilityaddresses", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacilityAddress>>(url);
        }

        /// <summary>
        /// Get all of the addresses associated with a single facility.
        /// </summary>
        /// <param name="facilityId">The id for the facility.</param>
        /// <returns>An array of all of the addresses associated with that facility.</returns>
        public RIDBFacilityAddress[] GetAllAddresses(int facilityId)
        {
            GetPageDelegate<RIDBFacilityAddress> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAddresses(facilityId, searchParams);
            };
            return Client.GetAll<RIDBFacilityAddress>(null, del);
        }

        /// <summary>
        /// Search the addresses for a specific facility.  The search utilizes the following search parameters:
        /// Query, Limit, and Offset.  The Query parameter is applied to the city, state, postal code, country code,
        /// and street address fields.
        /// </summary>
        /// <param name="facilityId">The id for the campsite.</param>
        /// <param name="searchParams">Search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBFacilityAddress> SearchAddresses(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/facilityaddresses", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacilityAddress>>(url);
        }

        /// <summary>
        /// Retrieve a specific address for a facility.
        /// </summary>
        /// <param name="facilityAddressId">The id for the facility address.</param>
        /// <returns>The facility address or null if not found.</returns>
        public RIDBFacilityAddress GetAddress(int facilityAddressId)
        {
            var url = Client.FormatSearchUrl("/facilityaddresses/{0}", new string[] { facilityAddressId.ToString() }, null);
            //return Client.MakeRequest<RIDBRecAreaAddress>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBFacilityAddress[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Retrieve all of the media objects associated with a facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of media objects.</returns>
        public RIDBEntityMedia[] GetAllMedia(int facilityId)
        {
            GetPageDelegate<RIDBEntityMedia> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchMedia(facilityId, searchParams);
            };
            return Client.GetAll<RIDBEntityMedia>(null, del);
        }

        /// <summary>
        /// Search the media associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the title, subtitle, description, credits, and media type fields.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBEntityMedia> SearchMedia(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/media", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityMedia>>(url);
        }

        /// <summary>
        /// Get a specific media item for a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="mediaId">The id of the media object.</param>
        /// <returns>A media object or null if not found.</returns>
        public RIDBEntityMedia GetMedia(int facilityId, int mediaId)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/media/{1}", new string[] { facilityId.ToString(), mediaId.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityMedia>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEntityMedia[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Retrieve all of the links associated with a facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of link objects.</returns>
        public RIDBEntityLink[] GetAllLinks(int facilityId)
        {
            GetPageDelegate<RIDBEntityLink> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchLinks(facilityId, searchParams);
            };
            return Client.GetAll<RIDBEntityLink>(null, del);
        }

        /// <summary>
        /// Search the links associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the title, description, and link type fields.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBEntityLink> SearchLinks(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/links", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityLink>>(url);
        }

        /// <summary>
        /// Get a specific link object for a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="entityLinkId">The id of the link object.</param>
        /// <returns>A link object or null if not found.</returns>
        public RIDBEntityLink GetLink(int facilityId, int entityLinkId)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/links/{1}", new string[] { facilityId.ToString(), entityLinkId.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityLink>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEntityLink[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Retrieve all events associated with a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of event objects.</returns>
        public RIDBEvent[] GetAllEvents(int facilityId)
        {
            GetPageDelegate<RIDBEvent> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchEvents(facilityId, searchParams);
            };
            return Client.GetAll<RIDBEvent>(null, del);
        }

        /// <summary>
        /// Search the events associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the  event name, start/end date, description, age group, ADA access, fee description, scope
        /// description, and type description fields.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBEvent> SearchEvents(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/events", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBEvent>>(url);
        }

        /// <summary>
        /// Get a specific event object for a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="eventId">The id of the event object.</param>
        /// <returns>An event object or null if not found.</returns>
        public RIDBEvent GetEvent(int facilityId, int eventId)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/events/{1}", new string[] { facilityId.ToString(), eventId.ToString() }, null);
            //return Client.MakeRequest<RIDBEvent>(url);
            // RIDB BUG:  This should return a single object but returns a single element array instead
            var singleElementArray = Client.MakeRequest<RIDBEvent[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Get all of the activities associated with a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of activity objects.</returns>
        public RIDBActivity[] GetAllActivities(int facilityId)
        {
            GetPageDelegate<RIDBActivity> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchActivities(facilityId, searchParams);
            };
            return Client.GetAll<RIDBActivity>(null, del);
        }

        /// <summary>
        /// Search the activities associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the activity name field.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBActivity> SearchActivities(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/activities", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBActivity>>(url);
        }

        /// <summary>
        /// Get a specific activity for a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="activityId">The id of the activity.</param>
        /// <returns>An activity object or null if not found.</returns>
        public RIDBActivity GetActivity(int facilityId, int activityId)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/activities/{1}", new string[] { facilityId.ToString(), activityId.ToString() }, null);
            //return Client.MakeRequest<RIDBActivity>(url);
            // RIDB BUG:  This call should return a single object but returns a single element array instead
            var resultArray = Client.MakeRequest<RIDBActivity[]>(url);
            if (resultArray == null || resultArray.Length == 0) return null;
            return resultArray[0];
        }

        /// <summary>
        /// Get all of the campsites associated with a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of campsite objects.</returns>
        public RIDBCampsite[] GetAllCampsites(int facilityId)
        {
            GetPageDelegate<RIDBCampsite> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchCampsites(facilityId, searchParams);
            };
            return Client.GetAll<RIDBCampsite>(null, del);
        }

        /// <summary>
        /// Search the campsites associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the campsite name, type, loop, type of use (Overnight/Day), campsite accessible (Yes/No) fields.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBCampsite> SearchCampsites(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/campsites", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBCampsite>>(url);
        }

        /// <summary>
        /// Get all of the permit entrances associated with a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of permit entrance objects.</returns>
        public RIDBPermitEntrance[] GetAllPermitEntrances(int facilityId)
        {
            GetPageDelegate<RIDBPermitEntrance> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchPermitEntrances(facilityId, searchParams);
            };
            return Client.GetAll<RIDBPermitEntrance>(null, del);
        }

        /// <summary>
        /// Search the permit entrances associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the permit name, type (Campground, Cabin, etc.), description, accessible (Yes/No), district, and town fields.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBPermitEntrance> SearchPermitEntrances(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/permitentrances", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermitEntrance>>(url);
        }

        /// <summary>
        /// Get all of the tours associated with a specific facility.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <returns>An array of tour objects.</returns>
        public RIDBTour[] GetAllTours(int facilityId)
        {
            GetPageDelegate<RIDBTour> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchTours(facilityId, searchParams);
            };
            return Client.GetAll<RIDBTour>(null, del);
        }

        /// <summary>
        /// Search the tours associated with a facility.  The Query, Offset, and Limit search parameters are supported.
        /// Query is applied to the tour name, type, description, and accessible (Yes/No) fields.
        /// </summary>
        /// <param name="facilityId">The id of the facility.</param>
        /// <param name="searchParams">The search parameters for the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBTour> SearchTours(int facilityId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/facilities/{0}/tours", new string[] { facilityId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBTour>>(url);
        }
    }
}
