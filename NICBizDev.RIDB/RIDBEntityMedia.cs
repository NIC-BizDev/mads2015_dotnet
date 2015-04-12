using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name = "EntityMedia")]
    public class RIDBEntityMedia
    {
        [DataMember]
        public string EntityType { get; set; }
        [DataMember]
        public int EntityID { get; set; }
        [DataMember]
        public string MediaType { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Subtitle { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Credits { get; set; }
        [DataMember]
        public int Height { get; set; }
        [DataMember]
        public int Width { get; set; }
        [DataMember]
        public string EmbedCode { get; set; }
    }
}
