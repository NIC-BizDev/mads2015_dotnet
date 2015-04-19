using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name = "RecAreaActivity")]
    public class RIDBRecAreaActivity
    {
        // RIDB BUG:  This whole entity is missing from the data dictionary
        [DataMember]
        public int ActivityID { get; set; }
        [DataMember]
        public String ActivityName { get; set; }
        [DataMember]
        public int ActivityLevel { get; set; }
        [DataMember]
        public int? ActivityParentID { get; set; }
        [DataMember]
        public string RecAreaActivityFeeDescription { get; set; }
        [DataMember]
        public string RecAreaActivityDescription { get; set; }
    }
}
