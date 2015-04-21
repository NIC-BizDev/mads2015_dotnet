using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="ZONES")]
    public class RIDBPermitEntranceZone
    {
        // RIDB BUG:  This whole class is missing from the documentation and examples
        [DataMember]
        public int PermitEntranceZoneID { get; set; }
        [DataMember]
        public string Zone { get; set; }
    }
}
