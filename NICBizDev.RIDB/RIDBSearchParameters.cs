using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name = "SEARCH_PARAMETERS")]
    public class RIDBSearchParameters
    {
        [DataMember(Name = "QUERY")]
        public string Query { get; set; }
        [IgnoreDataMember]
        public int? Offset { get; set; }
        [DataMember(Name = "OFFSET")]
        public float? OffsetFromJson
        {
            get { if (Offset.HasValue) return (float)Offset.Value; else return null; }
            set { if (value.HasValue) Offset = (int)value.Value; else Offset = null; }
        }
        [IgnoreDataMember]
        public int? Limit { get; set; }
        [DataMember(Name = "LIMIT")]
        public float? LimitFromJson
        {
            get { if (Limit.HasValue) return (float)Limit.Value; else return null; }
            set { if (value.HasValue) Limit = (int)value.Value; else Limit = null; }
        }
        // "METADATA":{"SEARCH_PARAMETERS":{"LASTUPDATED":"2005-04-18","STATE":"WY,MT,ID","QUERY":"yellowstone","ACTIVITY":"6,7","OFFSET":0.0,"LIMIT":25.0,
        // "LONGITUDE":-110.5867,"RADIUS":100.0,"LATITUDE":44.422573},"RESULTS":{"TOTAL_COUNT":4,"CURRENT_COUNT":4}}}
        [DataMember(Name = "LASTUPDATED")]
        public DateTime? LastUpdated { get; set; }
        [DataMember(Name = "STATE")]
        public string StateList { get; set; }
        [DataMember(Name = "ACTIVITY")]
        public string ActivityList { get; set; }
        [DataMember(Name = "LONGITUDE")]
        public double? Longitude { get; set; }
        [DataMember(Name = "LATITUDE")]
        public double? Latitude { get; set; }
        [DataMember(Name = "RADIUS")]
        public double? Radius { get; set; }
    }
}
