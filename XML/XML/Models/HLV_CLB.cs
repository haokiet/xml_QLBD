using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class HLV_CLB
    {

        public string VAITRO { get; set; }
        public virtual CLB CLB { get; set; }
        public virtual HLV MAHLV { get; set; }

    }
}