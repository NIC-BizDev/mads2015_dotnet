using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Tour")]
    public class RIDBTour
    {
        [DataMember]
        public int TourID;
        [DataMember]
        public int FacilityID;
        [DataMember]
        public string TourName;
        [DataMember]
        public string TourType;
        [DataMember]
        public string TourDescription;
        [DataMember]
        public string TourDuration;
        [DataMember]
        public string TourAccessible;
        //[DataMember]
        public DateTime CreatedDate;
        //[DataMember]
        public DateTime LastUpdatedDate;
    }
}
