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
    /// Represents an address associated with a recreation area.
    /// </summary>
    [DataContract(Name = "RecAreaAddress")]
    public class RIDBRecAreaAddress
    {
        // RIDB BUG : The AddressID and StreetAddress fields are missing the RecArea prefix in the documentation
        /// <summary>
        /// The id for the recreation area address.
        /// </summary>
        [DataMember]
        public int RecAreaAddressID { get; set; }

        /// <summary>
        /// The first line of the recreation area street address.
        /// </summary>
        [DataMember]
        public string RecAreaStreetAddress1 { get; set; }

        /// <summary>
        /// The second line of the recreation area street address.
        /// </summary>
        [DataMember]
        public string RecAreaStreetAddress2 { get; set; }

        /// <summary>
        /// The third line of the recreation area street address.
        /// </summary>
        [DataMember]
        public string RecAreaStreetAddress3 { get; set; }

        /// <summary>
        /// The city portion of the recreation area address.
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// The state code for the recreation area address.
        /// </summary>
        [DataMember]
        public string AddressStateCode { get; set; }

        /// <summary>
        /// The postal code for the recreation area address.
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country code for the recreation area address.
        /// </summary>
        [DataMember]
        public string AddressCountryCode { get; set; }

        /// <summary>
        /// The id of the recreation area with which the address is associated.
        /// </summary>
        [DataMember]
        public int RecAreaID { get; set; }

        /// <summary>
        /// The type of recreation area address.
        /// </summary>
        [DataMember]
        public string RecAreaAddressType { get; set; }
        
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        /// <summary>
        /// The date the record was last updated in RIDB.
        /// </summary>
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
        
        // RIDB BUG:  The PostalCode field is documented as a string but returned as a float in certain instances
        
    }
}
