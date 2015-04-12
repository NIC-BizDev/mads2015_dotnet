using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="EntityActivity")]
    public class RIDBEntityActivity
    {
        [DataMember]
        public int EntityID { get; set; }
        [DataMember]
        public string EntityType { get; set; }
        [DataMember]
        public int ActivityID { get; set; }
        [DataMember]
        public string ActivityDescription { get; set; }
        [DataMember]
        public string ActivityFeeDescription { get; set; }
    }
}
