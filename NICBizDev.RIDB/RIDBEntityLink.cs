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
        [DataMember]
        public string EntityType;
        [DataMember]
        public int EntityID;
        [DataMember]
        public string LinkType;
        [DataMember]
        public string URL;
        [DataMember]
        public string Title;
        [DataMember]
        public string Description;
    }
}
