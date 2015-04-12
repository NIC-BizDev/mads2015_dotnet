using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="OrgEntity")]
    public class RIDBOrgEntity
    {
        [DataMember]
        public int EntityID;
        [DataMember]
        public String EntityType;
        [DataMember]
        public int OrgID;
    }
}
