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
    /// Represents an address associated with a recreation facility.
    /// </summary>
    [DataContract(Name="FacilityAddress")]
    public class RIDBFacilityAddress
    {
        // RIDB BUG:  Documentation says this field is named AddressId but it is FacilityAddressID, likewise for the 3 address line fields which are missing the prefix in the documentation
        /// <summary>
        /// The id of the facility address.
        /// </summary>
        [DataMember]
        public int FacilityAddressID { get; set; }
        
        /// <summary>
        /// The first line of the facility street address.
        /// </summary>
        [DataMember]
        public string FacilityStreetAddress1 { get; set; }

        /// <summary>
        /// The second line of the facility street address.
        /// </summary>
        [DataMember]
        public string FacilityStreetAddress2 { get; set; }

        /// <summary>
        /// The third line of the facility street address.
        /// </summary>
        [DataMember]
        public string FacilityStreetAddress3 { get; set; }
        
        /// <summary>
        /// The city portion of the facility address.
        /// </summary>
        [DataMember]
        public string City { get; set; }
        
        /// <summary>
        /// The state code for the facility address.
        /// </summary>
        [DataMember]
        public string AddressStateCode { get; set; }
        
        /// <summary>
        /// The postal code for the facility address.
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }
        
        /// <summary>
        /// The country code for the facility address.
        /// </summary>
        [DataMember]
        public string AddressCountryCode { get; set; }
        
        /// <summary>
        /// The id of the facility with which the address is associated.
        /// </summary>
        [DataMember]
        public int FacilityID { get; set; }
        
        /// <summary>
        /// The type of facility address.
        /// </summary>
        [DataMember]
        public string FacilityAddressType { get; set; }
    }
}
