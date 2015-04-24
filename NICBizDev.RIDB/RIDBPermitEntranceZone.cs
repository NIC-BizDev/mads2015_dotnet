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
    /// Undocumented RIDB data object which relates to zones for permit entrances.
    /// </summary>
    [DataContract(Name="ZONES")]
    public class RIDBPermitEntranceZone
    {
        // RIDB BUG:  This whole class is missing from the documentation and examples
        /// <summary>
        /// The id of the permit entrance zone.
        /// </summary>
        [DataMember]
        public int PermitEntranceZoneID { get; set; }
        
        /// <summary>
        /// The name of the permit zone
        /// </summary>
        [DataMember]
        public string Zone { get; set; }
    }
}
