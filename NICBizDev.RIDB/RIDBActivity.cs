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
    /// Recreational activities.
    /// </summary>
    [DataContract(Name="RecreationalActivity")]
    public class RIDBActivity
    {
        /// <summary>
        /// Activity ID
        /// </summary>
        [DataMember]
        public int ActivityID { get; set; }
        
        // RIDB BUG:  The data dictionary incorrectly prefixes the next two fields with "Rec".
        /// <summary>
        /// Name of the activity
        /// </summary>
        [DataMember]
        public String ActivityName { get; set; }

        /// <summary>
        /// Amount of physical exertion to be expected for a given activity such as hiking, swimming, etc
        /// </summary>
        [DataMember]
        public int ActivityLevel { get; set; }

        // RIDB BUG:  Data dictionary is missing the ActivityParentID field
        /// <summary>
        /// The ActivityId of the activity's parent
        /// </summary>
        [DataMember]
        public int? ActivityParentID { get; set; }
    }
}
