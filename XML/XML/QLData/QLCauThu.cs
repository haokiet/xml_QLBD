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
            XmlElement san = doc.CreateElement("CAUTHU");


            san.AppendChild(createrNode<String>("MACT", t.MACT));
            san.AppendChild(createrNode<String>("HOTEN", t.HOTEN));
            san.AppendChild(createrNode<String>("VITRI", t.VITRI));
            san.AppendChild(createrNode<String>("NGAYSINH", t.NGAYSINH));
            san.AppendChild(createrNode<String>("DIACHI", t.DIACHI));
            san.AppendChild(createrNode<String>("MACLB", attributeToKey("CAULACBO", "TENCLB", t.MACLB, "MACLB")));
            san.AppendChild(createrNode<String>("MAQG", attributeToKey("QUOCGIA", "TENQG", t.MAQG, "MAQG")));
            san.AppendChild(createrNode<String>("SO", t.SO));
            return san;
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

        protected override string nameData()
        {
            return "CAUTHU";
        }

        protected override string nameKey()
        {
            return "MACT";
        }
    }
}