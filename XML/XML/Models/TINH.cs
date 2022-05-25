using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class TINH
    {
        public TINH()
        {
            this.CLBs = new HashSet<CLB>();
        }
        public string MATINH { get; set; }
        public string TENTINH { get; set; }

        public virtual ICollection<CLB> CLBs { get; set; }
    }
}