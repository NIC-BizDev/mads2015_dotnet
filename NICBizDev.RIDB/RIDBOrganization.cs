using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="Organization")]
    public class RIDBOrganization
    {
        [DataMember]
        public int OrgId { get; set; }
        [DataMember]
        public string OrgName { get; set; }
        [DataMember]
        public string OrgAbbrevName { get; set; }
        [DataMember]
        public string OrgURLAddress { get; set; }
        [DataMember]
        public string OrgURLText { get; set; }
        [DataMember]
        public string OrgImageURL { get; set; }
        [DataMember]
        public string OrgJurisdictionType { get; set; }
        // RIDB BUG:  LastUpdatedDate is missing from the data dictionary
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
    }
}
