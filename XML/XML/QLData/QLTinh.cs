using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLTinh : QLTong<TINH>
    {
        protected override XmlElement createrNewEle(TINH t)
        {
            XmlElement temp = doc.CreateElement("TINH");
            temp.AppendChild(createrNode<String>("MATINH", t.MATINH));
            temp.AppendChild(createrNode<String>("TENTINH", t.TENTINH));
            return temp;
        }
        protected override TINH createrOject(XmlNode item)
        {
            TINH temp = new TINH();
            temp.MATINH = item["MATINH"].InnerText;
            temp.TENTINH = item["TENTINH"].InnerText;
            return temp;

        }

        protected override string nameTable()
        {
            return "TINH";
        }

        protected override string namePrimarykey()
        {
            return "MATINH";
        }

        
    }
}