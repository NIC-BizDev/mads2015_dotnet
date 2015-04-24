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
    /// The client module used to access information about RIDB permit entrances.  To get only the entrances associated with a facility,
    /// use the facility module and call one of the permit entrance access methods on that module.  This module is for searching and retrieving
    /// permit entrances associated with all entities within RIDB.
    /// </summary>
    public class RIDBClientModPermitEntrance : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModPermitEntrance(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all permit entrances in RIDB.  Warning: this retrieves many recordss.  This method should be only used
        /// when all permit entrances need handled.
        /// </summary>
        /// <returns>An array containing all of the permit entrances in RIDB.</returns>
        public RIDBPermitEntrance[] GetAll()
        {
            GetPageDelegate<RIDBPermitEntrance> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBPermitEntrance>(null, del);
        }

        /// <summary>
        /// Search all of the permit entrances within RIDB and return matches.  The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the permit name, type (Campground, Cabin, etc.),
        /// description, accessible (Yes/No), district, and town fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBPermitEntrance> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/permitentrances", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermitEntrance>>(url);
        }

        /// <summary>
        /// Get a specific permit entrance.
        /// </summary>
        /// <param name="id">The id for the permit entrance.</param>
        /// <returns>The permit entrance object or null if not found.</returns>
        public RIDBPermitEntrance Get(int id)
        {
            var url = Client.FormatUrl("/permitentrances/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBPermitEntrance>(url);
        }

        /// <summary>
        /// Search the attributes associated with a specific permit entrance. The search utilizes the following search parameters:
        /// Query, Limit, and Offset.  Query is performed on the attribute name field. 
        /// </summary>
        /// <param name="permitEntranceId">The id of the permit entrance.</param>
        /// <param name="searchParams">The search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBAttribute> SearchAttributes(int permitEntranceId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/permitentrances/{0}/attributes", new string[] { permitEntranceId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBAttribute>>(url);
        }

        /// <summary>
        /// Retrieve all of the attributes associated with a permit entrance.
        /// </summary>
        /// <param name="permitEntranceId">The id of the permit entrance.</param>
        /// <returns>An array of all of the attributes for that permit entrance.</returns>
        public RIDBAttribute[] GetAllAttributes(int permitEntranceId)
        {
            GetPageDelegate<RIDBAttribute> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchAttributes(permitEntranceId, searchParams);
            };
            return Client.GetAll<RIDBAttribute>(null, del);
        }

        /// <summary>
        /// Search the zones associated with a specific permit entrance. No query parameters are documented as having an effect on the search. 
        /// </summary>
        /// <param name="permitEntranceId">The id of the permit entrance.</param>
        /// <param name="searchParams">The search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBPermitEntranceZone> SearchZones(int permitEntranceId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/permitentrances/{0}/zones", new string[] { permitEntranceId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermitEntranceZone>>(url);
        }

        /// <summary>
        /// Retrieve all of the zones associated with a permit entrance.
        /// </summary>
        /// <param name="permitEntranceId">The id of the permit entrance.</param>
        /// <returns>An array of all of the zones for that permit entrance.</returns>
        public RIDBPermitEntranceZone[] GetAllZones(int permitEntranceId)
        {
            GetPageDelegate<RIDBPermitEntranceZone> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchZones(permitEntranceId, searchParams);
            };
            return Client.GetAll<RIDBPermitEntranceZone>(null, del);
        }

        /// <summary>
        /// Get information about a specific zone of a permit entrance.
        /// </summary>
        /// <param name="permitEntranceId">The id of the permit entrance.</param>
        /// <param name="permitEntranceZoneId">The id of the entrance zone.</param>
        /// <returns>An entrance zone object or null if not found.</returns>
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
