﻿using System;
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
    /// Recreational activities which are associated with other entities like recreation areas and facilities.  This data type is
    /// defined in the RIDB API documentation but is not currently used.
    /// </summary>
    [DataContract(Name = "EntityActivity")]
    public class RIDBEntityActivity
    {
        /// <summary>
        /// The id of the entity with which this activity is associated.
        /// </summary>
        [DataMember]
        public int EntityID { get; set; }
        
        /// <summary>
        /// The type of the entity with which the activity is related (either Rec Area or Facility).
        /// </summary>
        [DataMember]
        public string EntityType { get; set; }
        
        /// <summary>
        /// The id of the activity.
        /// </summary>
        [DataMember]
        public int ActivityID { get; set; }
        
        /// <summary>
        /// The description of the activity.
        /// </summary>
        [DataMember]
        public string ActivityDescription { get; set; }
        
        /// <summary>
        /// A description of the fees associated with the activity.
        /// </summary>
        [DataMember]
        public string ActivityFeeDescription { get; set; }
    }
}
