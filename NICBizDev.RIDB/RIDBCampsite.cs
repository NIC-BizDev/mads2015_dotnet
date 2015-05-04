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
    /// RIDB data object encapsulating information stored in RIDB for a campsite.
    /// </summary>
    [DataContract(Name="Campsite")]
    public class RIDBCampsite
    {
        /// <summary>
        /// The id of the campsite.
        /// </summary>
        [DataMember]
        public int CampsiteID { get; set; }
        
        /// <summary>
        /// The id of the facility with which the campsite is associated.
        /// </summary>
        [DataMember]
        public int FacilityID { get; set; }
        
        /// <summary>
        /// The name of the campsite.
        /// </summary>
        [DataMember]
        public string CampsiteName { get; set; }
        
        /// <summary>
        /// The type of campsite.
        /// </summary>
        [DataMember]
        public string CampsiteType { get; set; }
        
        /// <summary>
        /// The loop on which the campsite resides.
        /// </summary>
        [DataMember]
        public string Loop { get; set; }
        
        /// <summary>
        /// The type of use allowed.
        /// </summary>
        [DataMember]
        public string TypeOfUse { get; set; }
        
        // RIDB BUG:  The field CampsiteAccessible is misspelled as CampsiteAccesible in the data dictionary.
        /// <summary>
        /// Whether the campsite is handicap accessible.
        /// </summary>
        [DataMember]
        public bool CampsiteAccessible { get; set; }
        
        /// <summary>
        /// The date the campsite record was created.
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
        
        // RIDB BUG:  In the data dictionary LastUpdatedDate is misnamed as LastUpdateDate
        /// <summary>
        /// The date the record was last updated within RIDB.
        /// </summary>
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
        
        // RIDB BUG:  The data dictionary is missing the ATTRIBUTES member
        /// <summary>
        /// The attributes associated with the campsite.
        /// </summary>
        [DataMember(Name = "ATTRIBUTES")]
        public RIDBAttribute[] Attributes { get; set; }
        
        // RIDB BUG:  The data dictionary is missing the PERMITTEDEQUIPMENT member
        /// <summary>
        /// The permitted equipment allowed at the campsite.
        /// </summary>
        [DataMember(Name = "PERMITTEDEQUIPMENT")]
        public RIDBPermittedEquipment[] PermittedEquipment { get; set; }
        
        // RIDB BUG:  The data dictionary is missing the ENTITYMEDIA member
        /// <summary>
        /// Media associated with the campsite.
        /// </summary>
        [DataMember(Name = "ENTITYMEDIA")]
        public RIDBEntityMedia[] Media { get; set; }

    }
}
