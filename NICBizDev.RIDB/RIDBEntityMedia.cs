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
    /// Information about multimedia associated with an entity within RIDB.
    /// </summary>
    [DataContract(Name = "EntityMedia")]
    public class RIDBEntityMedia
    {
        // RIDB BUG:  The MediaID is ommitted from the API documentation and is needed for the get method
        /// <summary>
        /// The id of the media item.
        /// </summary>
        [DataMember]
        public int MediaID { get; set; }
        
        /// <summary>
        /// The type of entity with which the media item is related (e.g. Rec Area or Facility).
        /// </summary>
        [DataMember]
        public string EntityType { get; set; }
        
        /// <summary>
        /// The id of the entity with which the media item is related.
        /// </summary>
        [DataMember]
        public int EntityID { get; set; }
        
        /// <summary>
        /// The type of media item (e.g. Image, Video, etc.)
        /// </summary>
        [DataMember]
        public string MediaType { get; set; }
        
        /// <summary>
        /// The Internet URL for the media item.
        /// </summary>
        [DataMember]
        public string URL { get; set; }
        
        /// <summary>
        /// Full title of the entity media.
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        
        /// <summary>
        /// Optional subtitle of the entity media.
        /// </summary>
        [DataMember]
        public string Subtitle { get; set; }
        
        /// <summary>
        /// Optional description of the entity media.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        
        /// <summary>
        /// Optional credits for the entity media item.
        /// </summary>
        [DataMember]
        public string Credits { get; set; }
        
        /// <summary>
        /// Height in pixels for media item.
        /// </summary>
        [DataMember]
        public int Height { get; set; }
        
        /// <summary>
        /// Width in pixels for the media item.
        /// </summary>
        [DataMember]
        public int Width { get; set; }
        
        /// <summary>
        /// Optional embedded code used to insert the media into a webpage.
        /// </summary>
        [DataMember]
        public string EmbedCode { get; set; }
    }
}
