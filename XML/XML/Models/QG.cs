using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class QG
    {
        public QG()
        {
            this.CauThu = new HashSet<CauThu>();
            this.HLVs = new HashSet<HLV>();
        }

        public string MAQG { get; set; }
        public string TENQG { get; set; }

        public virtual ICollection<CauThu> CauThu { get; set; }
        public virtual ICollection<HLV> HLVs { get; set; }
    }
}