using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="RecAreaAddress")]
    public class RIDBRecAreaAddress
    {
        // RIDB BUG : The AddressID and StreetAddress fields are missing the RecArea prefix in the documentation
        [DataMember]
        public int RecAreaAddressID { get; set; }
        [DataMember]
        public string RecAreaStreetAddress1 { get; set; }
        [DataMember]
        public string RecAreaStreetAddress2 { get; set; }
        [DataMember]
        public string RecAreaStreetAddress3 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string AddressStateCode { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string AddressCountryCode { get; set; }
        [DataMember]
        public int RecAreaID { get; set; }
        [DataMember]
        public string RecAreaAddressType { get; set; }
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
        // RIDB BUG:  The PostalCode field is documented as a string but returned as a float in certain instances
        
    }
}
