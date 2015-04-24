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
    /// Information about a recreation facility in RIDB.
    /// </summary>
    [DataContract(Name="Facility")]
    public class RIDBFacility
    {
        /// <summary>
        /// The id for the facility.
        /// </summary>
        [DataMember]
        public int FacilityID { get; set; }
        
        // RIDB BUG: OrgFacilityID is documented as an integer, but has string data returned
        /// <summary>
        /// The optional oganization specific id for the facility.
        /// </summary>
        [DataMember]
        public string OrgFacilityID { get; set; }
        
        /// <summary>
        /// The name of the facility.
        /// </summary>
        [DataMember]
        public string FacilityName { get; set; }
        
        /// <summary>
        /// A description for the facility type.
        /// </summary>
        [DataMember]
        public string FacilityTypeDescription { get; set; }
        
        /// <summary>
        /// The phone number of the facility.
        /// </summary>
        [DataMember]
        public string FacilityPhone { get; set; }
        
        /// <summary>
        /// A description of the facility.
        /// </summary>
        [DataMember]
        public string FacilityDescription { get; set; }
        
        /// <summary>
        /// Optional text that provides general directions and/or the general location of the facility.
        /// </summary>
        [DataMember]
        public string FacilityDirections { get; set; }
        
        /// <summary>
        /// Email contact for the facility.
        /// </summary>
        [DataMember]
        public string FacilityEmail { get; set; }
        
        /// <summary>
        /// Internet address (URL) for a facility map.
        /// </summary>
        [DataMember]
        public string FacilityMapURL { get; set; }
        
        /// <summary>
        /// Internet address (URL) for the website hosting the reservation system.
        /// </summary>
        [DataMember]
        public string FacilityReservationURL { get; set; }
        
        /// <summary>
        /// Latitude in decimal degrees -90.0 to 90.0.
        /// </summary>
        [DataMember]
        public double? FacilityLatitude { get; set; }
        
        /// <summary>
        /// Longitude in decimal degrees -180.0 to 180.0.
        /// </summary>
        [DataMember]
        public double? FacilityLongitude { get; set; }
        
        /// <summary>
        /// Information about the Americans with Disabilities Act accessibility for the facility.
        /// </summary>
        [DataMember]
        public string FacilityAdaAccess { get; set; }
        
        /// <summary>
        /// Text describing monetary charges associated with entrance to or usage of the facility.
        /// </summary>
        [DataMember]
        public string FacilityUseFeeDescription { get; set; }
        
        /// <summary>
        /// The legacy id for the facility.
        /// </summary>
        [DataMember]
        public string LegacyFacilityID { get; set; }
        
        /// <summary>
        /// List of keywords for the facility.
        /// </summary>
        [DataMember]
        public string Keywords { get; set; }
        
        /// <summary>
        /// Details on the stay limits for the facility.
        /// </summary>
        [DataMember]
        public string StayLimit { get; set; }
        
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        /// <summary>
        /// The date the record was last updated in RIDB.
        /// </summary>
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
    }
}
