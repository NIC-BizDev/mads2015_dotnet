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
        // RIDB BUG:  In the data dictionary LastUpdatedDate is misnamed as LastUpdateDate
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
        // RIDB BUG:  The data dictionary is missing the ATTRIBUTES member
        [DataMember(Name = "ATTRIBUTES")]
        public RIDBAttribute[] Attributes { get; set; }
        // RIDB BUG:  The data dictionary is missing the PERMITTEDEQUIPMENT member
        [DataMember(Name = "PERMITTEDEQUIPMENT")]
        public RIDBPermittedEquipment[] PermittedEquipment { get; set; }
        // RIDB BUG:  The data dictionary is missing the ENTITYMEDIA member
        [DataMember(Name = "ENTITYMEDIA")]
        public RIDBEntityMedia[] Media { get; set; }

    }
}
