using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="PermittedEquipment")]
    public class RIDBPermittedEquipment
    {
        [DataMember]
        public string EquipmentName { get; set; }
        [DataMember]
        public int MaxLength { get; set; }
    }
}
