using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    /// A single page of RIDB search results.  The RIDB API returns results in pages of up to 50 results.  The type
    /// of data object in the result varies by type of search and must be supplied as a type parameter.
    /// </summary>
    /// <typeparam name="T">The type of RIDB data object in the results.</typeparam>
    [DataContract(Name="ResultList")]
    public class RIDBList<T>
    {
        /// <summary>
        /// The search result data objects.
        /// </summary>
        [DataMember(Name = "RECDATA")]
        public T[] Data { get; set; }

        /// <summary>
        /// The metadata about the search that was performed.
        /// </summary>
        [DataMember(Name = "METADATA")]
        public RIDBListMetdata MetaData { get; set; }

        /// <summary>
        /// The number of data objects returned from the search.
        /// </summary>
        [IgnoreDataMember]
        public int Count { get { if (Data == null) return 0; else return Data.Length; } }

        /// <summary>
        /// Returns true of the results page is empty.
        /// </summary>
        [IgnoreDataMember]
        public bool IsEmpty { get { return Count == 0; } }
    }

    /// <summary>
    /// The metadata returned from a search request.
    /// </summary>
    [DataContract(Name="METADATA")]
    public class RIDBListMetdata
    {
        /// <summary>
        /// The search parameters used for the search.
        /// </summary>
        [DataMember(Name="SEARCH_PARAMETERS")]
        public RIDBSearchParameters SearchParameters { get; set; }

        /// <summary>
        /// The results metadata.
        /// </summary>
        [DataMember(Name = "RESULTS")]
        public RIDBListResultMetadata Results { get; set; }
        
    }

    /// <summary>
    /// Encapsulates the search metadata that comes back from RIDB.
    /// </summary>
    [DataContract(Name = "RESULTS")]
    public class RIDBListResultMetadata
    {
        /// <summary>
        /// The total count of results matching the search.
        /// </summary>
        [DataMember(Name = "TOTAL_COUNT")]
        public int? TotalCount { get; set; }

        /// <summary>
        /// The number of results returned in the results page.
        /// </summary>
        [DataMember(Name = "CURRENT_COUNT")]
        public int? CurrentCount { get; set; }
    }

}
