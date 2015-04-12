using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Facility")]
    public class RIDBFacility
    {
        [DataMember]
        public int FacilityID { get; set; }
        //[DataMember]
        public int OrgFacilityID { get; set; }
        [DataMember]
        public string FacilityName { get; set; }
        [DataMember]
        public string FacilityTypeDescription { get; set; }
        [DataMember]
        public string FacilityPhone { get; set; }
        [DataMember]
        public string FacilityDescription { get; set; }
        [DataMember]
        public string FacilityDirections { get; set; }
        [DataMember]
        public string FacilityEmail { get; set; }
        [DataMember]
        public string FacilityMapURL { get; set; }
        [DataMember]
        public string FacilityReservationURL { get; set; }
        [DataMember]
        public string FacilityLatitude { get; set; }
        [DataMember]
        public string FacilityLongitude { get; set; }
        [DataMember]
        public string FacilityAdaAccess { get; set; }
        [DataMember]
        public string FacilityUseFeeDescription { get; set; }
        [DataMember]
        public string LegacyFacilityID { get; set; }
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public string StayLimit { get; set; }
    }
}
