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
        // RIDB BUG:  Documentation says this field is named AddressId but it is FacilityAddressID, likewise for the 3 address line fields which are missing the prefix in the documentation
        [DataMember]
        public int FacilityAddressID { get; set; }
        [DataMember]
        public string FacilityStreetAddress1 { get; set; }
        [DataMember]
        public string FacilityStreetAddress2 { get; set; }
        [DataMember]
        public string FacilityStreetAddress3 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string AddressStateCode { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string AddressCountryCode { get; set; }
        [DataMember]
        public int FacilityID { get; set; }
        [DataMember]
        public string FacilityAddressType { get; set; }
    }
}
