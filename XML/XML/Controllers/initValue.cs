using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XML.Models;

namespace XML.Controllers
{
    public class initValue : Controller
    {
        
        XmlDocument doc = new XmlDocument();
        string file;
        XmlElement root;
        public string File1 { get => Server.MapPath("/DataSource/XMLFile1.xml"); set => file = value; }
        private void init()
        {
            doc.Load(File1);
            root = doc.DocumentElement;
        }
    }
}