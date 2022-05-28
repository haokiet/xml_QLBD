using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLHLV : QLTong<HLV>
    {
        protected override XmlElement createrNewEle(HLV t)
        {
            XmlElement temp = doc.CreateElement(nameTable());


            temp.AppendChild(createrNode<String>("MAHLV", t.MAHLV));
            temp.AppendChild(createrNode<String>("TENHLV", t.TENHLV));
            temp.AppendChild(createrNode<String>("NGAYSINH", t.NGAYSINH));
            temp.AppendChild(createrNode<String>("DIACHI", t.DIACHI));
            temp.AppendChild(createrNode<String>("DIENTHOAI", t.DIENTHOAI));
            temp.AppendChild(createrNode<String>("MAQG", attributeToKey("QUOCGIA", "TENQG", t.MAQG, "MAQG")));
            return temp;
        }

        protected override HLV createrOject(XmlNode item)
        {
            HLV temp = new HLV();

            temp.MAHLV = item["MAHLV"].InnerText;
            temp.TENHLV = item["TENHLV"].InnerText;
            temp.NGAYSINH = item["NGAYSINH"].InnerText;
            temp.DIACHI = item["DIACHI"].InnerText;
            temp.DIENTHOAI = item["DIENTHOAI"].InnerText;
            temp.MAQG = keyToAttribute("QUOCGIA", "MAQG", item, "TENQG");
            return temp;
        }

        protected override string namePrimarykey()
        {
            return "MAHLV";
        }

        protected override string nameTable()
        {
            return "HLV";
        }
    }
}