using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="FacilityAddress")]
    public class RIDBFacilityAddress
    {
        [DataMember]
        public int addressID { get; set; }
        [DataMember]
        public string streetAddress1 { get; set; }
        [DataMember]
        public string streetAddress2 { get; set; }
        [DataMember]
        public string streetAddress3 { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string addressStateCode { get; set; }
        [DataMember]
        public string postalCode { get; set; }
        [DataMember]
        public string addressCountryCode { get; set; }
        [DataMember]
        public int facilityID { get; set; }
        [DataMember]
        public string facilityAddressType { get; set; }
    }
}
