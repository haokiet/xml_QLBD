using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLTran : QLTong<TRANDAU>
    {
        protected override XmlElement createrNewEle(TRANDAU t)
        {
            XmlElement temp = doc.CreateElement(nameTable());


            temp.AppendChild(createrNode<String>("MATRAN", t.MATRAN));
            temp.AppendChild(createrNode<String>("NAM", t.NAM));
            temp.AppendChild(createrNode<String>("NGAYTD", t.NGAYTD));
            temp.AppendChild(createrNode<String>("MONG", t.VONG));
            temp.AppendChild(createrNode<String>("MACLB1", attributeToKey("CAULACBO", "TENCLB", t.MACLB1, "MACLB")));
            temp.AppendChild(createrNode<String>("MACLB2", attributeToKey("CAULACBO", "TENCLB", t.MACLB2, "MACLB")));
            temp.AppendChild(createrNode<String>("MASAN", attributeToKey("SANVD", "TENSAN", t.MASAN, "MASAN")));
            temp.AppendChild(createrNode<String>("KETQUA", t.KETQUA));
            return temp;
        }

        protected override TRANDAU createrOject(XmlNode item)
        {
            TRANDAU temp = new TRANDAU();

            temp.MATRAN = item["MATRAN"].InnerText;
            temp.NAM = item["NAM"].InnerText;
            temp.NGAYTD = item["NGAYTD"].InnerText;
            temp.VONG = item["VONG"].InnerText;
            temp.MACLB1 = keyToAttribute("CAULACBO", "MACLB", item, "TENCLB","1");
            temp.MACLB2 = keyToAttribute("CAULACBO", "MACLB", item, "TENCLB","2");
            temp.MASAN = keyToAttribute("SANVD", "MASAN", item, "TENSAN");
            temp.KETQUA = item["KETQUA"].InnerText;
            return temp;
        }

        protected override string namePrimarykey()
        {
            return "MATRAN";
        }

        protected override string nameTable()
        {
            return "TRANDAU";
        }
    }
}