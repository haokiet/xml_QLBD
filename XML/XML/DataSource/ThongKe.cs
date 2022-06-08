using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Xsl;

namespace XML.DataSource
{
    public class ThongKe
    {
        [Obsolete]
        static void Main(string[] args)
        {
            string baseName = System.Environment.CurrentDirectory;
            XslTransform myXslTransform;
            myXslTransform = new XslTransform();
            myXslTransform.Load(baseName+ "~/DataSource/XSLTFile1.xslt");
            myXslTransform.Transform(baseName + "~/DataSource/XMLFile1.xml", baseName+ "~/DataSource/ThongKe.xml");
        }
    }
}