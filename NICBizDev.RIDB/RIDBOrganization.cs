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
    /// An organizational entity within RIDB.
    /// </summary>
    [DataContract(Name="Organization")]
    public class RIDBOrganization
    {
        /// <summary>
        /// The id of the organization.
        /// </summary>
        [DataMember]
        public int OrgId { get; set; }
        
        /// <summary>
        /// The organization name.
        /// </summary>
        [DataMember]
        public string OrgName { get; set; }
        
        /// <summary>
        /// Short form of the organization name.
        /// </summary>
        [DataMember]
        public string OrgAbbrevName { get; set; }
        
        /// <summary>
        /// The URL address of the organization's website.
        /// </summary>
        [DataMember]
        public string OrgURLAddress { get; set; }
        
        /// <summary>
        /// The text that should be used for links to the organization's website
        /// </summary>
        [DataMember]
        public string OrgURLText { get; set; }
        
        /// <summary>
        /// URL to an image to use for the organization.
        /// </summary>
        [DataMember]
        public string OrgImageURL { get; set; }
        
        /// <summary>
        /// Optional jurisdiction type for the organization.
        /// </summary>
        [DataMember]
        public string OrgJurisdictionType { get; set; }
        
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        /// <summary>
        /// Date that the organization was last updated in RIDB.
        /// </summary>
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
    }
}
