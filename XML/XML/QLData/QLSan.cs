using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLSan : QLTong<SAN>
    {


        protected override XmlElement createrNewEle(SAN t)
        {

            XmlElement temp = doc.CreateElement("SANVD");

            temp.AppendChild(createrNode<String>("MASAN", t.MASAN));
            temp.AppendChild(createrNode<String>("TENSAN", t.TENSAN));
            temp.AppendChild(createrNode<String>("DIACHI", t.DIACHI));
            return temp;
        }

        protected override SAN createrOject(XmlNode item)
        {
            SAN temp = new SAN();
            temp.MASAN = item["MASAN"].InnerText;
            temp.TENSAN = item["TENSAN"].InnerText;
            temp.DIACHI = item["DIACHI"].InnerText;
            return temp;
        }

        protected override string nameTable()
        {
            return "SANVD";
        }

        protected override string namePrimarykey()
        {
            return "MASAN";
        }
    }
}