using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="RecArea")]
    public class RIDBRecArea
    {
        [DataMember]
        public int RecAreaID { get; set; }
        [IgnoreDataMember]
        public int? OrgRecAreaID { get; set; }
        [DataMember]
        public string RecAreaName { get; set; }
        [DataMember]
        public string RecAreaDescription { get; set; }
        [DataMember]
        public string RecAreaDirections { get; set; }
        [DataMember]
        public string RecAreaFeeDescription { get; set; }
        [DataMember]
        public string RecAreaMapURL { get; set; }
        [DataMember]
        public string RecAreaReservationURL { get; set; }
        [DataMember]
        public string RecAreaPhone { get; set; }
        [DataMember]
        public string RecAreaEmail { get; set; }
        [DataMember]
        public double? RecAreaLatitude { get; set; }
        [DataMember]
        public double? RecAreaLongitude { get; set; }
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public string StayLimit { get; set; }
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }

        // RIDB BUG:  The OrgRecAreaID field is documented as an integer but returned as a float in the JSON
        [DataMember(Name="OrgRecAreaID")]
        public float? OrgRecAreaIDFromJson
        {
            get { if (OrgRecAreaID.HasValue) return (float)OrgRecAreaID; else return null; }
            set { if (value.HasValue) OrgRecAreaID = (int)value.Value; else OrgRecAreaID = null; }
        }
    }

}
