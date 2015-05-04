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
    /// Represents a permitted recreation entrance.
    /// </summary>
    [DataContract(Name = "PermitEntrance")]
    public class RIDBPermitEntrance
    {
        /// <summary>
        /// The id of the permit entrance.
        /// </summary>
        [DataMember]
        public int PermitEntranceID { get; set; }
        
        /// <summary>
        /// The id of the facility with which the permit entrance is associated.
        /// </summary>
        [DataMember]
        public int FacilityID { get; set; }
        
        /// <summary>
        /// The name of the permit entrance.
        /// </summary>
        [DataMember]
        public string PermitEntranceName { get; set; }
        
        /// <summary>
        /// The type of the permit entrance.
        /// </summary>
        [DataMember]
        public string PermitEntranceType { get; set; }
        
        /// <summary>
        /// A description of the permit entrance.
        /// </summary>
        [DataMember]
        public string PermitEntranceDescription { get; set; }
        
        // RIDB BUG:  The field is misspelled in the data dictionary as "PermitEntranceAccesible"
        /// <summary>
        /// Details about the accessibility of the permit entrance.
        /// </summary>
        [DataMember]
        public string PermitEntranceAccessible { get; set; }
        
        /// <summary>
        /// Latitude of the permit location.
        /// </summary>
        [DataMember]
        public double? Latitude { get; set; }
        
        /// <summary>
        /// Longitude of the permit location.
        /// </summary>
        [DataMember]
        public double? Longitude { get; set; }
        
        /// <summary>
        /// District the permit resides in.
        /// </summary>
        [DataMember]
        public string District { get; set; }
        
        /// <summary>
        /// Town the permit resides in.
        /// </summary>
        [DataMember]
        public string Town { get; set; }
        
        /// <summary>
        /// Zone the permit resides in.
        /// </summary>
        [DataMember]
        public string Zone { get; set; }
        
        /// <summary>
        /// Record creation date.
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Record last update date.
        /// </summary>
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
        
        // RIDB BUG:  The data dictionary is missing the ATTRIBUTES member
        /// <summary>
        /// The attributes associated with the permit entrance.
        /// </summary>
        [DataMember(Name = "ATTRIBUTES")]
        public RIDBAttribute[] Attributes { get; set; }

        // RIDB BUG:  The data dictionary is missing the ZONES member and no description of the Zone object is provided
        /// <summary>
        /// The zones to which the permit relates.
        /// </summary>
        [DataMember(Name = "ZONES")]
        public RIDBPermitEntranceZone[] Zones { get; set; }
    }
}
