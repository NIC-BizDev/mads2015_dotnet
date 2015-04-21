using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NICBizDev.RIDB
{
    [DataContract(Name="MEMBERTOURS")]
    public class RIDBMemberTour
    {
        // "MEMBERTOURS":[{"MemberTourID":317399},{"MemberTourID":317500}],
        [DataMember]
        public int MemberTourId { get; set; }
    }
}
