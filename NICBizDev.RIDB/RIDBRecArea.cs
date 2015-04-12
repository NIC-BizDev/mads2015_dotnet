using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="RecArea")]
    public class RIDBRecArea
    {
        [DataMember]
        public int RecAreaID { get; set; }
        //[DataMember]
        public int? OrgRecAreaID { get; set; }
        [DataMember]
        public string RecAreaName { get; set; }
        [DataMember]
        public string RecAreaDescription { get; set; }
        [DataMember]
        public string RecAreaDirections { get; set; }
        [DataMember]
        public string RecAreaFeeDescription { get; set; }
        [DataMember]
        public string RecAreaMapURL { get; set; }
        [DataMember]
        public string RecAreaReservationURL { get; set; }
        [DataMember]
        public string RecAreaPhone { get; set; }
        [DataMember]
        public string RecAreaEmail { get; set; }
        [DataMember]
        public string RecAreaLatitude { get; set; }
        [DataMember]
        public string RecAreaLongitude { get; set; }
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public string StayLimit { get; set; }
    }
}
