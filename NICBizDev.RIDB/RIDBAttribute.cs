using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Attribute")]
    public class RIDBAttribute
    {
        [DataMember]
        public string AttributeName { get; set; }
        [DataMember]
        public string AttributeValue { get; set; }
        // RIDB BUG:  The AttributeID field is omitted from the data dictionary
        [DataMember]
        public int? AttributeID { get; set; }
    }
}
