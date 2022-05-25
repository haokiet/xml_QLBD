using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class CLB
    {
        public CLB()
        {
            this.HLV_CLBs = new HashSet<HLV_CLB>();
        }
        public string MACLB { get; set; }
        public string TENCLB { get; set; }
        public virtual SAN MASAN { get; set; }
        public virtual TINH MATINH { get; set; }

        public virtual ICollection<HLV_CLB> HLV_CLBs { get; set; }
    }
}