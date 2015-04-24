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
    /// The client module used to access information about RIDB organizations.  This module also
    /// allows you to retrieve the recreation areas and facilities associated with an organziation.
    /// </summary>
    public class RIDBClientModOrg : RIDBClientModule
    {
        /// <summary>
        /// Create the module during initialization of the client.
        /// </summary>
        /// <param name="client">The client that owns the module.</param>
        public RIDBClientModOrg(RIDBClient client) : base(client) { ; }

        /// <summary>
        /// Retrieve all organizations in RIDB.
        /// </summary>
        /// <returns>An array containing all of the organizations in RIDB.</returns>
        public RIDBOrganization[] GetAll()
        {
            GetPageDelegate<RIDBOrganization> del = delegate(RIDBSearchParameters searchParams)
            {
                return Search(searchParams);
            };
            return Client.GetAll<RIDBOrganization>(null, del);
        }

        /// <summary>
        /// Search all of the organizations within RIDB and return matches.  The Query, Limit, and Offset search
        /// parameters are supported.  The Query parameter is applied to the organization name and organization abbreviated name fields.
        /// </summary>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBOrganization> Search(RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/organizations/", new string[0], searchParams);
            return Client.MakeRequest<RIDBList<RIDBOrganization>>(url);
        }

        /// <summary>
        /// Get a specific organization.
        /// </summary>
        /// <param name="id">The id for the organization.</param>
        /// <returns>The organization object or null if not found.</returns>
        public RIDBOrganization Get(int id)
        {
            var url = Client.FormatSearchUrl("/organizations/{0}", new string[] { id.ToString() }, null);
            // RIDB bug:  For some reason this call returns a single element array instead of just the organization object
            var workaround = Client.MakeRequest<RIDBOrganization[]>(url);
            if (workaround == null || workaround.Length < 1) return null;
            return workaround[0];
        }

        /// <summary>
        /// Retrieve all rec areas associated with a specific organization.
        /// </summary>
        /// <param name="orgId">The id for the organization.</param>
        /// <returns>An array containing all of the recreation areas associated with an organization.</returns>
        public RIDBRecArea[] GetAllRecAreas(int orgId)
        {
            GetPageDelegate<RIDBRecArea> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchRecAreas(orgId, searchParams);
            };
            return Client.GetAll<RIDBRecArea>(null, del);
        }

        /// <summary>
        /// Search the recreation areas associated with a specific organization and return matches.  All search
        /// parameters are supported.  The Query parameter is applied to the recreation area name, description, keywords, and stay limit fields.
        /// </summary>
        /// <param name="orgId">The id for the organization.</param>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBRecArea> SearchRecAreas(int orgId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/organizations/{0}/recareas", new string[] { orgId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBRecArea>>(url);
        }

        /// <summary>
        /// Retrieve all facilities associated with a specific organization.
        /// </summary>
        /// <param name="orgId">The id for the organization.</param>
        /// <returns>An array containing all of the facilities associated with an organization.</returns>
        public RIDBFacility[] GetAllFacilities(int orgId)
        {
            GetPageDelegate<RIDBFacility> del = delegate(RIDBSearchParameters searchParams)
            {
                return SearchFacilities(orgId, searchParams);
            };
            return Client.GetAll<RIDBFacility>(null, del);
        }

        /// <summary>
        /// Search the facilities associated with a specific organization and return matches.  All search
        /// parameters are supported.  The Query parameter is applied to the facility name, description, keywords, and stay limit fields.
        /// </summary>
        /// <param name="orgId">The id for the organization.</param>
        /// <param name="searchParams">Search parameters to use in the search.</param>
        /// <returns>A single page of RIDB search results.</returns>
        public RIDBList<RIDBFacility> SearchFacilities(int orgId, RIDBSearchParameters searchParams)
        {
            var url = Client.FormatSearchUrl("/organizations/{0}/facilities", new string[] { orgId.ToString() }, searchParams);
            return Client.MakeRequest<RIDBList<RIDBFacility>>(url);
        }
    }
}
