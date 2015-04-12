using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name = "PermitEntrance")]
    public class RIDBPermitEntrance
    {
        [DataMember]
        public int PermitEntranceID { get; set; }
        [DataMember]
        public int FacilityID { get; set; }
        [DataMember]
        public string PermitEntranceName { get; set; }
        [DataMember]
        public string PermitEntranceType { get; set; }
        [DataMember]
        public string PermitEntranceDescription { get; set; }
        [DataMember]
        public string PermitEntranceAccesible { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string Zone { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
    }
}
