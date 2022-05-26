using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
namespace XML.Controllers
{
    public abstract class Class1
    {
        XmlDocument doc = new XmlDocument();
        string file = @"C:\Users\trimi\source\repos\XML\XML\DataSource\XMLFile1.xml";
        XmlElement root;
        public string File1 { get => HttpContext.Current.Server.MapPath("/DataSource/XMLFile1.xml"); set => file = value; }
        protected Class1()
        {

            doc.Load(file);
            root = doc.DocumentElement;
        }

        public void them()
        {

        }
    }
}