using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;
namespace XML.QLData
{
    public class QLCLB: QLTong<CLB>
    {
        protected override XmlElement createrNewEle(CLB t)
        {
            XmlElement temp = doc.CreateElement(nameTable());


            temp.AppendChild(createrNode<String>("MACLB", t.MACLB));
            temp.AppendChild(createrNode<String>("TENCLB", t.TENCLB));
            temp.AppendChild(createrNode<String>("MASAN", attributeToKey("SANVD", "TENSAN", t.MASAN, "MASAN")));
            temp.AppendChild(createrNode<String>("MATINH", attributeToKey("TINH", "TENTINH", t.MATINH, "MATINH")));
            return temp;
        }

        protected override CLB createrOject(XmlNode item)
        {
            CLB temp = new CLB();

            temp.MACLB = item["MACLB"].InnerText;
            temp.TENCLB = item["TENCLB"].InnerText;
            temp.MASAN = keyToAttribute("SANVD", "MASAN", item, "TENSAN");
            temp.MATINH = keyToAttribute("TINH", "MATINH", item, "TENTINH");
            return temp;
        }

        protected override string namePrimarykey()
        {
            return "MACLB";
        }

        protected override string nameTable()
        {
            return "CAULACBO";
        }
    }

}