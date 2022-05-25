using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class SAN
    {
        public SAN()
        {
            this.CLBs = new HashSet<CLB>();
        }
        public string MASAN { get; set; }
        public string TENSAN { get; set; }
        public string DIACHI { get; set; }
        public virtual ICollection<CLB> CLBs { get; set; }
    }
}