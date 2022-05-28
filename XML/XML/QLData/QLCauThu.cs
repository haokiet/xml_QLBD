using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLCauThu : QLTong<CAUTHU>
    {
        protected override XmlElement createrNewEle(CAUTHU t)
        {
            XmlElement temp = doc.CreateElement("CAUTHU");


            temp.AppendChild(createrNode<String>("MACT", t.MACT));
            temp.AppendChild(createrNode<String>("HOTEN", t.HOTEN));
            temp.AppendChild(createrNode<String>("VITRI", t.VITRI));
            temp.AppendChild(createrNode<String>("NGAYSINH", t.NGAYSINH));
            temp.AppendChild(createrNode<String>("DIACHI", t.DIACHI));
            temp.AppendChild(createrNode<String>("MACLB", attributeToKey("CAULACBO", "TENCLB", t.MACLB, "MACLB")));
            temp.AppendChild(createrNode<String>("MAQG", attributeToKey("QUOCGIA", "TENQG", t.MAQG, "MAQG")));
            temp.AppendChild(createrNode<String>("SO", t.SO));
            return temp;
        }

        protected override CAUTHU createrOject(XmlNode item)
        {
            CAUTHU temp = new CAUTHU();

            temp.MACT = item["MACT"].InnerText;
            temp.HOTEN = item["HOTEN"].InnerText;
            temp.VITRI = item["VITRI"].InnerText;
            temp.NGAYSINH = item["NGAYSINH"].InnerText;
            temp.DIACHI = item["DIACHI"].InnerText;
            temp.SO = item["SO"].InnerText;
            temp.MACLB = keyToAttribute("CAULACBO", "MACLB", item, "TENCLB");
            temp.MAQG = keyToAttribute("QUOCGIA", "MAQG", item, "TENQG");
            return temp;
        }

        protected override string nameTable()
        {
            return "CAUTHU";
        }

        protected override string namePrimarykey()
        {
            return "MACT";
        }
    }
}