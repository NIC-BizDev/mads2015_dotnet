using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Campsite")]
    public class RIDBCampsite
    {
        [DataMember]
        public int CampsiteID { get; set; }
        [DataMember]
        public int FacilityID { get; set; }
        [DataMember]
        public string CampsiteName { get; set; }
        [DataMember]
        public string CampsiteType { get; set; }
        [DataMember]
        public string Loop { get; set; }
        [DataMember]
        public string TypeOfUse { get; set; }
        [DataMember]
        public bool CampsiteAccesible { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime LastUpdateDate { get; set; }
    }
}
