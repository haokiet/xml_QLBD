using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XML.Models;

namespace XML.QLData
{
    public class QLQG : QLTong<QG>
    {
        protected override XmlElement createrNewEle(QG t)
        {
            XmlElement temp = doc.CreateElement("QUOCGIA");


            temp.AppendChild(createrNode<String>("MAQG", t.MAQG));
            temp.AppendChild(createrNode<String>("TENQG", t.TENQG));

            return temp;
        }

        protected override QG createrOject(XmlNode item)
        {
            QG temp = new QG();

            temp.TENQG = item["TENQG"].InnerText;
            temp.MAQG = item["MAQG"].InnerText;
            return temp;
        }

        protected override string nameTable()
        {
            return "QUOCGIA";
        }

        protected override string namePrimarykey()
        {
            return "MAQG";
        }
    }
}