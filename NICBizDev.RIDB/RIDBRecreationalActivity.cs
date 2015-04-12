using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="RecreationalActivity")]
    public class RIDBRecreationalActivity
    {
        [DataMember]
        public int ActivityID { get; set; }
        [DataMember]
        public String RecActivityName { get; set; }
        [DataMember]
        public int RecActivityLevel { get; set; }
    }
}
