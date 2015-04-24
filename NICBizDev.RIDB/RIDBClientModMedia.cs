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
    /// The client module used to access information about RIDB media.  To get only the media associated with other
    /// entities, such as recreation areas and facilities, use the appropriate module for that
    /// entity and call one of the media access methods on that entity.  This module is for searching and retrieving
    /// media associated with all entities within RIDB.
    /// </summary>
    public class RIDBClientModMedia : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModMedia(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all media references in RIDB.  Warning: this retrieves all pages of media results and will return thousands
        /// of objects.  This method should be only used when all media objects need handled at the same time.
        /// </summary>
        /// <returns>An array containing all of the media references in RIDB.</returns>
        public RIDBEntityMedia[] GetAll()
        {
            GetPageDelegate<RIDBEntityMedia> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBEntityMedia>(null, del);
        }

        /// <summary>
        /// Search all of the media objects within RIDB and return matches.  The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the title, subtitle, description, credits, and media type fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBEntityMedia> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/media", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBEntityMedia>>(url);
        }

        /// <summary>
        /// Get a specific media object.
        /// </summary>
        /// <param name="id">The id for the media object.</param>
        /// <returns>The media object or null if not found.</returns>
        public RIDBEntityMedia Get(int id)
        {
            var url = Client.FormatUrl("/media/{0}", new string[] { id.ToString() }, null);
            //return Client.MakeRequest<RIDBEntityMedia>(url);
            // RIDB BUG:  Instead of returning a single media object the API returns a single element array
            var singleElementArray = Client.MakeRequest<RIDBEntityMedia[]>(url);
            if (singleElementArray == null || singleElementArray.Length == 0) return null;
            return singleElementArray[0];

        }
    }
}
