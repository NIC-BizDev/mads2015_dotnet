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
    /// Undocumented object type that is returned when accessing RIDB activities for recreation areas.  It contains
    /// the basic activity information plus some additional fields.
    /// </summary>
    [DataContract(Name = "RecAreaActivity")]
    public class RIDBRecAreaActivity
    {
        // RIDB BUG:  This whole entity is missing from the data dictionary
        /// <summary>
        /// The id for the activity.
        /// </summary>
        [DataMember]
        public int ActivityID { get; set; }
        
        /// <summary>
        /// The name of the activity.
        /// </summary>
        [DataMember]
        public String ActivityName { get; set; }
        
        /// <summary>
        /// The intensity level of the activity.
        /// </summary>
        [DataMember]
        public int ActivityLevel { get; set; }
        
        /// <summary>
        /// The optional parent id if the activity is a child activity.
        /// </summary>
        [DataMember]
        public int? ActivityParentID { get; set; }
        
        /// <summary>
        /// A description of the fees associated with an activity at a recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaActivityFeeDescription { get; set; }

        /// <summary>
        /// A description of the activity at a recreation area.
        /// </summary>
        [DataMember]
        public string RecAreaActivityDescription { get; set; }
    }
}
