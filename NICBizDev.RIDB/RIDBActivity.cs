using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="RecreationalActivity")]
    public class RIDBActivity
    {
        [DataMember]
        public int ActivityID { get; set; }
        // RIDB BUG:  The data dictionary incorrectly prefixes the next two fields with "Rec".
        [DataMember]
        public String ActivityName { get; set; }
        [DataMember]
        public int ActivityLevel { get; set; }
        // RIDB BUG:  Data dictionary is missing the ActivityParentID field
        [DataMember]
        public int? ActivityParentID { get; set; }
    }
}
