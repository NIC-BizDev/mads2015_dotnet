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
    /// The client module used to access information about RIDB tours.  To get the tours associated with facilities, use the
    /// facilities module and call the tour access methods.  This module is for searching and retrieving
    /// tour information for tours associated with all entities within RIDB.
    /// </summary>
    public class RIDBClientModTour : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModTour(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all tours in RIDB.  Warning: this retrieves all pages of tour results.  This method
        /// should be only used when all tours need handled at once.
        /// </summary>
        /// <returns>An array containing all of the tours in RIDB.</returns>
        public RIDBTour[] GetAll()
        {
            GetPageDelegate<RIDBTour> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBTour>(null, del);
        }

        /// <summary>
        /// Search all of the tours within RIDB and return matches.  The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the tour name, type, description, and accessible (Yes/No) fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBTour> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/tours", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBTour>>(url);
        }

        /// <summary>
        /// Get a specific tour.
        /// </summary>
        /// <param name="id">The id for the tour.</param>
        /// <returns>The tour object or null if not found.</returns>
        public RIDBTour Get(int id)
        {
            var url = Client.FormatUrl("/tours/{0}", new string[] { id.ToString() }, null);
            return Client.MakeRequest<RIDBTour>(url);
            
        }

        /// <summary>
        /// Search the attributes associated with a specific tour. The search utilizes the following search parameters:
        /// Query, Limit, and Offset.  Query is performed on the attribute name field. 
        /// </summary>
        /// <param name="tourId">The id of the tour.</param>
        /// <param name="searchParams">The search parameters to apply to the search.</param>
        /// <returns>A page of RIDB search results.</returns>
        public RIDBList<RIDBAttribute> SearchAttributes(int tourId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/tours/{0}/attributes", new string[] { tourId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBAttribute>>(url);
        }

        /// <summary>
        /// Retrieve all of the attributes associated with a tour.
        /// </summary>
        /// <param name="tourId">The id of the tour.</param>
        /// <returns>An array of all of the attributes for that tour.</returns>
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
