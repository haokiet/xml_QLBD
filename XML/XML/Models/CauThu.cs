using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    public partial class CauThu
    {
        public string MACT { get; set; }
        public string HOTEN { get; set; }
        public string VITRI { get; set; }
        public string NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string SO { get; set; }

        public virtual CLB CLB { get; set; }
        public virtual QG QG { get; set; }
    }
}