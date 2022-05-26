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

            XmlElement san = doc.CreateElement("SANVD");

            XmlElement MASAN = doc.CreateElement("MASAN");
            MASAN.InnerText = t.MASAN;
            san.AppendChild(MASAN);

            XmlElement TENSAN = doc.CreateElement("TENSAN");
            TENSAN.InnerText = t.TENSAN;
            san.AppendChild(TENSAN);

            XmlElement DIACHI = doc.CreateElement("DIACHI");
            DIACHI.InnerText = t.DIACHI;
            san.AppendChild(DIACHI);

            return san;
        }

        protected override SAN createrOject(XmlNode item)
        {
            SAN temp = new SAN();
            temp.MASAN = item["MASAN"].InnerText;
            temp.TENSAN = item["TENSAN"].InnerText;
            temp.DIACHI = item["DIACHI"].InnerText;
            return temp;
        }

        protected override string nameData()
        {
            return "SANVD";
        }

        protected override string nameKey()
        {
            return "MASAN";
        }
    }
}