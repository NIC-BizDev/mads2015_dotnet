using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Event")]
    public class RIDBEvent
    {
        [DataMember]
        public int EventID { get; set; }
        [DataMember]
        public int EntityID { get; set; }
        [DataMember]
        public string EntityType { get; set; }
        [DataMember]
        public int? EventDataStewardID { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public DateTime EventStartDate { get; set; }
        [DataMember]
        public string EventDescription { get; set; }
        [DataMember]
        public string EventAgeGroup { get; set; }
        [DataMember]
        public string EventURLAddress { get; set; }
        [DataMember]
        public string EventURLText { get; set; }
        [DataMember]
        public string EventEmail { get; set; }
        [DataMember]
        public bool EventRegistrationRequired { get; set; }
        [DataMember]
        public string EventADAAccess { get; set; }
        [DataMember]
        public string EventFeeDescription { get; set; }
        [DataMember]
        public string EventComments { get; set; }
        [DataMember]
        public string EventFrequencyRateDescription { get; set; }
        [DataMember]
        public string EventScopeDescription { get; set; }
        [DataMember]
        public string EventTypeDescription { get; set; }
        [DataMember]
        public string SponsorName { get; set; }
        [DataMember]
        public string SponsorEmail { get; set; }
        [DataMember]
        public string SponsorURLAddress { get; set; }
        [DataMember]
        public DateTime EventEndDate { get; set; }
        [DataMember]
        public string SponsorURLText { get; set; }
        [DataMember]
        public string SponsorPhone { get; set; }
        [DataMember]
        public string SponsorClassType { get; set; }
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
    }
        
}
