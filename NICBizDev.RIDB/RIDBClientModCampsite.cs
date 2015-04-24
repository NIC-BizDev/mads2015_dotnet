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
    /// The client module used to access information about RIDB campsites.  To get the campsites associated with other
    /// entities, such as recreation areas and facilities, use the appropriate module for that
    /// entity and call one of the campsite access methods on that entity.  This module is for searching and retrieving
    /// campsite information for all campsites in RIDB.
    /// </summary>
    public class RIDBClientModCampsite : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModCampsite(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all campsites in RIDB.  Warning: this retrieves thousands of records and takes
        /// quite a while to pull all pages of campsite results.  This method should be only used
        /// when all campsites need handled.
        /// </summary>
        /// <returns>An array containing all of the campsites in RIDB.</returns>
        public RIDBCampsite[] GetAll()
        {
            GetPageDelegate<RIDBCampsite> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBCampsite>(null, del);
        }

        /// <summary>
        /// Search all of the campsites within RIDB and return matches.  The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the campsite name, type, loop, type of use
        /// (Overnight/Day), and campsite accessible (Yes/No) fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBCampsite> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/campsites", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBCampsite>>(url);
        }

        /// <summary>
        /// Get a specific campsite.
        /// </summary>
        /// <param name="id">The id for the campsite.</param>
        /// <returns>The campsite object or null if not found.</returns>
        public RIDBCampsite Get(int id)
        {
            var url = Client.FormatUrl("/campsites/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBCampsite>(url);
            // RIDB BUG:  Instead of returning a single campsite object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBCampsite[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Search the permitted equipment for a specific campsite.  The search utilizes the following search parameters:
        /// Query, Limit, and Offset.  Query is performed on the equipment name and max length (in feet) fields.
        /// </summary>
        /// <param name="campsiteId">The id for the campsite.</param>
        /// <param name="searchParams">Search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBPermittedEquipment> SearchPermittedEquipment(int campsiteId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/campsites/{0}/permittedequipment", new string[] { campsiteId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBPermittedEquipment>>(url);
        }

        /// <summary>
        /// Retrieve all permitted equipment for a specific campsite.
        /// </summary>
        /// <param name="campsiteId">The id for the campsite.</param>
        /// <returns>An array containing all of the permitted equipment for that campsite.</returns>
        public RIDBPermittedEquipment[] GetAllPermittedEquipment(int campsiteId)
        {
            GetPageDelegate<RIDBPermittedEquipment> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchPermittedEquipment(campsiteId, searchParams);
            };
            return Client.GetAll<RIDBPermittedEquipment>(null, del);
        }

        /// <summary>
        /// Retrieve a specific permitted equipment object for a given campsite.
        /// </summary>
        /// <param name="campsiteId">The id of the campsite.</param>
        /// <param name="permittedEquipmentId">The id for the permitted equipment object.</param>
        /// <returns>The permitted equipment object or null if not found.</returns>
        public RIDBPermittedEquipment GetPermittedEquipment(int campsiteId, int permittedEquipmentId)
        {
            var url = Client.FormatUrl("/campsites/{0}/permittedequipment/{1}", new string[] { campsiteId.ToString(), permittedEquipmentId.ToString() }, null);
            //return Client.MakeRequest<RIDBPermittedEquipment>(url);
            // RIDB BUG:  Instead of returning a single permitted equipment object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBPermittedEquipment[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];
        }

        /// <summary>
        /// Search the attributes associated with a specific campsite. The search utilizes the following search parameters:
        /// Query, Limit, and Offset.  Query is performed on the attribute name field. 
        /// </summary>
        /// <param name="campsiteId">The id of the campsite.</param>
        /// <param name="searchParams">The search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBAttribute> SearchAttributes(int campsiteId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/campsites/{0}/attributes", new string[] { campsiteId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBAttribute>>(url);
        }

        /// <summary>
        /// Retrieve all of the attributes associated with a campsite.
        /// </summary>
        /// <param name="campsiteId">The id of the campsite.</param>
        /// <returns>An array of all of the attributes for that campsite.</returns>
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
