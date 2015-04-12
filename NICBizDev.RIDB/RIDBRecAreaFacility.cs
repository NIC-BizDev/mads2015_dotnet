using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="RecAreaFacility")]
    public class RIDBRecAreaFacility
    {
        [DataMember]
        public int RecAreaID { get; set; }
        [DataMember]
        public int FacilityID { get; set; }
    }
}
