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
    /// The client module used to access information about RIDB events.  To get the campsites associated with other
    /// entities, such as recreation areas and facilities, use the appropriate module for that
    /// entity and call one of the event access methods on that entity.  This module is for searching and retrieving
    /// event information for all events in RIDB.
    /// </summary>
    public class RIDBClientModEvent : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModEvent(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all events in RIDB.  Warning: this retrieves all pages of event results and can
        /// take awhile to complete.  This method should be only used when all events need handled.
        /// </summary>
        /// <returns>An array containing all of the events in RIDB.</returns>
        public RIDBEvent[] GetAll()
        {
            GetPageDelegate<RIDBEvent> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBEvent>(null, del);
        }

        /// <summary>
        /// Search all of the events within RIDB and return matches.  The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the event name, start/end date,
        /// description, age group, ADA access, fee description, scope description, and type description fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBEvent> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/events", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBEvent>>(url);
        }

        /// <summary>
        /// Get a specific event.
        /// </summary>
        /// <param name="id">The id for the event.</param>
        /// <returns>The event object or null if not found.</returns>
        public RIDBEvent Get(int id)
        {
            var url = Client.FormatUrl("/events/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBEvent>(url);
            // RIDB BUG:  Instead of returning a single event object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBEvent[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
