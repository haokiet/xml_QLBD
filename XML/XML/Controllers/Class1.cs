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
        protected Class1()
        {
            this.doc.Load(file);
            root = this.doc.DocumentElement;
        }

        public void them()
        {

        }
    }
}