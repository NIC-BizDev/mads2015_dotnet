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
    /// The client module used to access information about RIDB recreation activities.  To get activity information
    /// related to other entities, such as recreation areas and facilities, use the appropriate module for that
    /// entity.  This module is for loading and searching the universe of activities in the system.
    /// </summary>
    public class RIDBClientModActivity : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModActivity(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all activities from RIDB.
        /// </summary>
        /// <returns>Array contraining all RIDB activities.</returns>
        public RIDBActivity[] GetAll()
        {
            GetPageDelegate<RIDBActivity> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBActivity>(null, del);
        }

        /// <summary>
        /// Search for a specific set of activities.  Search parameters used by the search are
        /// Query, Limit, and Offset.  Query searches are executed against the activity name.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBActivity> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/activities", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBActivity>>(url);
        }

        /// <summary>
        /// Get a specific activity.
        /// </summary>
        /// <param name="id">The id for the activity.</param>
        /// <returns>The activity object or null if not found.</returns>
        public RIDBActivity Get(int id)
        {
            var url = Client.FormatUrl("/activities/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBActivity>(url);
            // RIDB BUG:  Instead of returning a single activity object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBActivity[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
