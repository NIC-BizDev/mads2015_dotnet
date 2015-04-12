using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract]
    public class RIDBRecAreaEvent
    {
        [DataMember]
        public int RecAreaID;
        [DataMember]
        public int EventID;
    }
}
