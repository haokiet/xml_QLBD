using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLHLV_CLB : QLTong<HLV_CLB>
    {
        protected override XmlElement createrNewEle(HLV_CLB t)
        {
            XmlElement temp = doc.CreateElement(nameTable());


            temp.AppendChild(createrNode<String>("VAITRO", t.VAITRO));
            temp.AppendChild(createrNode<String>("MACLB", attributeToKey("CAULACBO", "TENCLB", t.MACLB, "MACLB")));
            temp.AppendChild(createrNode<String>("MAHLV", attributeToKey("HLV", "TENHLV", t.MAHLV, "MAHLV")));
            return temp;
        }

        protected override HLV_CLB createrOject(XmlNode item)
        {
            HLV_CLB temp = new HLV_CLB();

            temp.VAITRO = item["VAITRO"].InnerText;
            temp.MACLB = keyToAttribute("CAULACBO", "MACLB", item, "TENCLB");
            temp.MAHLV = keyToAttribute("HLV", "MAHLV", item, "TENHLV");
            return temp;
        }

        protected override string namePrimarykey()
        {
            return "MAHLV";
        }

        protected override string nameTable()
        {
            return "HLV_CLB";
        }
    }
}