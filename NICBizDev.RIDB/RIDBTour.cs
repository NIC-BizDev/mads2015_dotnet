using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Tour")]
    public class RIDBTour
    {
        [DataMember]
        public int TourID;
        [DataMember]
        public int FacilityID;
        [DataMember]
        public string TourName;
        [DataMember]
        public string TourType;
        [DataMember]
        public string TourDescription;
        [DataMember]
        public string TourDuration;
        [DataMember]
        public string TourAccessible;
        [DataMember]
        public DateTime? CreatedDate;
        [DataMember]
        public DateTime? LastUpdatedDate;
        // RIDB BUG:  The data dictionary is missing the ATTRIBUTES member
        [DataMember(Name = "ATTRIBUTES")]
        public RIDBAttribute[] Attributes { get; set; }
        // RIDB BUG:  The data dictionary is missing the MEMBERTOURS member
        [DataMember(Name = "MEMBERTOURS")]
        public RIDBMemberTour[] MemberTours { get; set; }
        // RIDB BUG:  The data dictionary is missing the ENTITYMEDIA member
        [DataMember(Name = "ENTITYMEDIA")]
        public RIDBEntityMedia[] Media { get; set; }
    }
}
