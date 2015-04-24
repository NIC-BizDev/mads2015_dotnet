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
    /// Information about a recreation area in RIDB.
    /// </summary>
    [DataContract(Name = "RecArea")]
    public class RIDBRecArea
    {
        /// <summary>
        /// The id of the recreation area.
        /// </summary>
        [DataMember]
        public int RecAreaID { get; set; }
        
        /// <summary>
        /// The optional organization specific identifier for the recreation area.
        /// </summary>
        [IgnoreDataMember]
        public int? OrgRecAreaID { get; set; }
        
        /// <summary>
        /// The name of the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaName { get; set; }
        
        /// <summary>
        /// Description of the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaDescription { get; set; }
        
        /// <summary>
        /// Directions and/or general information about the entrances.
        /// </summary>
        [DataMember]
        public string RecAreaDirections { get; set; }
        
        /// <summary>
        /// A description of the fees associated with the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaFeeDescription { get; set; }
        
        /// <summary>
        /// A URL to a map of the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaMapURL { get; set; }
        
        /// <summary>
        /// The link to the reservation website for making reservations in the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaReservationURL { get; set; }
        
        /// <summary>
        /// Phone number for the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaPhone { get; set; }
        
        /// <summary>
        /// Email contact for the recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaEmail { get; set; }


        /// <summary>
        /// Latitude in decimal degrees -90.0 to 90.0.
        /// </summary>
        [DataMember]
        public double? RecAreaLatitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees -180.0 to 180.0.
        /// </summary>
        [DataMember]
        public double? RecAreaLongitude { get; set; }

        /// <summary>
        /// List of keywords for the recreation area.
        /// </summary>
        [DataMember]
        public string Keywords { get; set; }

        /// <summary>
        /// Details on the stay limits for the recreation area.
        /// </summary>
        [DataMember]
        public string StayLimit { get; set; }
        
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        /// <summary>
        /// The date the record was last updated in RIDB.
        /// </summary>
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }

        // RIDB BUG:  The OrgRecAreaID field is documented as an integer but returned as a float in the JSON
        /// <summary>
        /// Workaround property that converts the delivered float to the expected int value.
        /// </summary>
        [DataMember(Name="OrgRecAreaID")]
        public float? OrgRecAreaIDFromJson
        {
            get { if (OrgRecAreaID.HasValue) return (float)OrgRecAreaID; else return null; }
            set { if (value.HasValue) OrgRecAreaID = (int)value.Value; else OrgRecAreaID = null; }
        }
    }

}
