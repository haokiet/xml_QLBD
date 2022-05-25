using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class HLV
    {
        public HLV()
        {
            this.HLV_CLBs = new HashSet<HLV_CLB>();
        }
        public string MAHLV { get; set; }
        public string TENHLV { get; set; }
        public string NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string DIENTHOAI { get; set; }

        public virtual QG QG { get; set; }

        public virtual ICollection<HLV_CLB> HLV_CLBs { get; set; }
    }
}