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
        [DataMember]
        public int AddressID;
        [DataMember]
        public string StreetAddress1;
        [DataMember]
        public string StreetAddress2;
        [DataMember]
        public string StreetAddress3;
        [DataMember]
        public string City;
        [DataMember]
        public string AddressStateCode;
        [DataMember]
        public string PostalCode;
        [DataMember]
        public string AddressCountryCode;
        [DataMember]
        public int RecAreaID;
        [DataMember]
        public string RecAreaAddressType;
    }
}
