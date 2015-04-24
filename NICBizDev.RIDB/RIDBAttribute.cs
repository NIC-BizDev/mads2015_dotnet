using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
    /// Attributes are key/value pairs that are associated with other entities, such as campsites and tours.
    /// </summary>
    [DataContract(Name="Attribute")]
    public class RIDBAttribute
    {
        /// <summary>
        /// The name of the attribute.
        /// </summary>
        [DataMember]
        public string AttributeName { get; set; }
        
        /// <summary>
        /// The value of the attribute.
        /// </summary>
        [DataMember]
        public string AttributeValue { get; set; }
        
        // RIDB BUG:  The AttributeID field is omitted from the data dictionary
        /// <summary>
        /// The id for the attribute.  Note that this is not always populated with a value depending on how the attribute is retrieved.
        /// </summary>
        [DataMember]
        public int? AttributeID { get; set; }
    }
}
