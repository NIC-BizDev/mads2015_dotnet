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
    /// Search parameters are used to refine a search to only certain results.  Not all search
    /// parameters are supported by every search method.  Please consult the documentation for
    /// the search method to see what parameters are supported.
    /// </summary>
    [DataContract(Name = "SEARCH_PARAMETERS")]
    public class RIDBSearchParameters
    {
        /// <summary>
        /// A substring to use in a case-insensitive substring search of certain data fields on an object.
        /// </summary>
        [DataMember(Name = "QUERY")]
        public string Query { get; set; }
        
        /// <summary>
        /// The number of records to skip when accessing pages of results.
        /// </summary>
        [IgnoreDataMember]
        public int? Offset { get; set; }
        
        /// <summary>
        /// A workaround property for the offset being returned as a float instead of an int.
        /// </summary>
        [DataMember(Name = "OFFSET")]
        public float? OffsetFromJson
        {
            get { if (Offset.HasValue) return (float)Offset.Value; else return null; }
            set { if (value.HasValue) Offset = (int)value.Value; else Offset = null; }
        }
        
        /// <summary>
        /// The maximum number of results to return in the results page.  The maximum allowed and default value is 50.
        /// </summary>
        [IgnoreDataMember]
        public int? Limit { get; set; }
        
        /// <summary>
        /// A workaround property for the limit being returned as a float instead of an int.
        /// </summary>
        [DataMember(Name = "LIMIT")]
        public float? LimitFromJson
        {
            get { if (Limit.HasValue) return (float)Limit.Value; else return null; }
            set { if (value.HasValue) Limit = (int)value.Value; else Limit = null; }
        }
        // "METADATA":{"SEARCH_PARAMETERS":{"LASTUPDATED":"2005-04-18","STATE":"WY,MT,ID","QUERY":"yellowstone","ACTIVITY":"6,7","OFFSET":0.0,"LIMIT":25.0,
        // "LONGITUDE":-110.5867,"RADIUS":100.0,"LATITUDE":44.422573},"RESULTS":{"TOTAL_COUNT":4,"CURRENT_COUNT":4}}}
        
        /// <summary>
        /// Only return results updated since a certain date.
        /// </summary>
        [DataMember(Name = "LASTUPDATED")]
        public DateTime? LastUpdated { get; set; }
        
        /// <summary>
        /// Only return results related to states in the abbreviation list string provided.
        /// </summary>
        [DataMember(Name = "STATE")]
        public string StateList { get; set; }
        
        /// <summary>
        /// Only return results related to the activities specified as a list of activity ids.
        /// </summary>
        [DataMember(Name = "ACTIVITY")]
        public string ActivityList { get; set; }
        
        /// <summary>
        /// Only return results near a certain longitude.
        /// </summary>
        [DataMember(Name = "LONGITUDE")]
        public double? Longitude { get; set; }
        
        /// <summary>
        /// Only return results near a certain latitude.
        /// </summary>
        [DataMember(Name = "LATITUDE")]
        public double? Latitude { get; set; }
        
        /// <summary>
        /// When matching against longitude and latitude, use this radius.
        /// </summary>
        [DataMember(Name = "RADIUS")]
        public double? Radius { get; set; }
    }
}
