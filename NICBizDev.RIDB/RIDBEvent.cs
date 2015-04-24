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
    /// Information about an event in RIDB.
    /// </summary>
    [DataContract(Name="Event")]
    public class RIDBEvent
    {
        /// <summary>
        /// The id for the event.
        /// </summary>
        [DataMember]
        public int EventID { get; set; }
        
        /// <summary>
        /// The id of the entity with which the event is related.
        /// </summary>
        [DataMember]
        public int EntityID { get; set; }
        
        /// <summary>
        /// The type of entity with which the event is related (e.g. Rec Area or Facility).
        /// </summary>
        [DataMember]
        public string EntityType { get; set; }
        
        /// <summary>
        /// The id of the data steward organization for the event.
        /// </summary>
        [DataMember]
        public int? EventDataStewardID { get; set; }
        
        /// <summary>
        /// The name of the event.
        /// </summary>
        [DataMember]
        public string EventName { get; set; }
        
        /// <summary>
        /// The start date for the event.
        /// </summary>
        [DataMember]
        public DateTime EventStartDate { get; set; }
        
        /// <summary>
        /// A description of the event.
        /// </summary>
        [DataMember]
        public string EventDescription { get; set; }
        
        /// <summary>
        /// Optional target age group for the event.
        /// </summary>
        [DataMember]
        public string EventAgeGroup { get; set; }
        
        /// <summary>
        /// Internet address (URL) to a web site providing details about the event.
        /// </summary>
        [DataMember]
        public string EventURLAddress { get; set; }
        
        /// <summary>
        /// Optional text to be displayed for the URL of the event.
        /// </summary>
        [DataMember]
        public string EventURLText { get; set; }
        
        /// <summary>
        /// Email contact for the event.
        /// </summary>
        [DataMember]
        public string EventEmail { get; set; }
        
        /// <summary>
        /// Whether registration is required for an event.
        /// </summary>
        [DataMember]
        public bool EventRegistrationRequired { get; set; }
        
        /// <summary>
        /// Whether the event is ADA accessible.
        /// </summary>
        [DataMember]
        public string EventADAAccess { get; set; }
        
        /// <summary>
        /// Description of fees associated with the event.
        /// </summary>
        [DataMember]
        public string EventFeeDescription { get; set; }
        
        /// <summary>
        /// Optional comments about the event.
        /// </summary>
        [DataMember]
        public string EventComments { get; set; }
        
        /// <summary>
        /// Text that describes how often the event recurs.
        /// </summary>
        [DataMember]
        public string EventFrequencyRateDescription { get; set; }
        
        /// <summary>
        /// Text that describes the extent, capacity, and scale of an event.
        /// </summary>
        [DataMember]
        public string EventScopeDescription { get; set; }
        
        /// <summary>
        /// Text that describes the type of event.
        /// </summary>
        [DataMember]
        public string EventTypeDescription { get; set; }
        
        /// <summary>
        /// Full Name of the sponsor for the event.
        /// </summary>
        [DataMember]
        public string SponsorName { get; set; }
        
        /// <summary>
        /// Sponsor email address for the event.
        /// </summary>
        [DataMember]
        public string SponsorEmail { get; set; }
        
        /// <summary>
        /// Internet address (URL) to a web site for the sponsor.
        /// </summary>
        [DataMember]
        public string SponsorURLAddress { get; set; }
        
        /// <summary>
        /// The end date for the event.
        /// </summary>
        [DataMember]
        public DateTime EventEndDate { get; set; }
        
        /// <summary>
        /// Optional readable text for the URL sponsor link.
        /// </summary>
        [DataMember]
        public string SponsorURLText { get; set; }
        
        /// <summary>
        /// Phone number for the sponsor of the event.
        /// </summary>
        [DataMember]
        public string SponsorPhone { get; set; }
        
        /// <summary>
        /// Class and type of sponsor.
        /// </summary>
        [DataMember]
        public string SponsorClassType { get; set; }
        
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        /// <summary>
        /// The date the event was last updated in RIDB.
        /// </summary>
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
    }
        
}
