using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="EntityLink")]
    public class RIDBEntityLink
    {
        // RIDB BUG:  The EntityLinkID field is missing from the data dictionary
        [DataMember]
        public int EntityLinkID { get; set; }
        [DataMember]
        public string EntityType { get; set; }
        [DataMember]
        public int EntityID { get; set; }
        [DataMember]
        public string LinkType { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
