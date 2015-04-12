using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name = "FacilityEvent")]
    public class RIDBFacilityEvent
    {
        [DataMember]
        public int FacilityID { get; set; }
        [DataMember]
        public int EventID { get; set; }
    }
}
